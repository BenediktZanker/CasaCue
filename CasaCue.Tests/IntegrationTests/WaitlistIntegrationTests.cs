using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;


namespace CasaCue.Tests.IntegrationTests
{
    public class WaitlistIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public WaitlistIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetWaitlist_ShouldReturnEmptyListInitially()
        {
            // Reset the waitlist
            await _client.DeleteAsync("/api/waitlist/reset");

            // Act
            var response = await _client.GetAsync("/api/waitlist");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Equal("[]", responseContent); // Expect an empty list
        }

        [Fact]
        public async Task AddGuest_ShouldReturnCreatedGuest()
        {
            // Reset the waitlist
            await _client.DeleteAsync("/api/waitlist/reset");

            // Arrange
            var guest = new { Id = Guid.NewGuid(), Name = "John Doe", GroupSize = 3 };
            var jsonContent = new StringContent(JsonSerializer.Serialize(guest), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/waitlist", jsonContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("John Doe", responseContent);
        }

        [Fact]
        public async Task RemoveGuest_ShouldDeleteGuest()
        {
            // Reset the waitlist
            await _client.DeleteAsync("/api/waitlist/reset");

            // Arrange
            var guest = new { Id = Guid.NewGuid(), Name = "Jane Doe", GroupSize = 2 };
            var jsonContent = new StringContent(JsonSerializer.Serialize(guest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/waitlist", jsonContent);

            // Act
            var deleteResponse = await _client.DeleteAsync($"/api/waitlist/{guest.Id}");
            var getResponse = await _client.GetAsync($"/api/waitlist/id/{guest.Id}");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteResponse.StatusCode);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [Fact]
        public async Task GetGuestById_ShouldReturnCorrectGuest()
        {
            // Reset the waitlist
            await _client.DeleteAsync("/api/waitlist/reset");

            // Arrange
            var id = Guid.NewGuid();
            var guest = new { Id = id, Name = "Alice", GroupSize = 4 };
            var jsonContent = new StringContent(JsonSerializer.Serialize(guest), Encoding.UTF8, "application/json");
            await _client.PostAsync("/api/waitlist", jsonContent);

            // Act
            var response = await _client.GetAsync($"/api/waitlist/id/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("Alice", responseContent);
        }

        [Fact]
        public async Task GetGuestByQueuePosition_ShouldReturnCorrectGuest()
        {
            // Reset the waitlist
            await _client.DeleteAsync("/api/waitlist/reset");

            // Arrange
            var guest1 = new { Id = Guid.NewGuid(), Name = "Bob", GroupSize = 2 };
            var guest2 = new { Id = Guid.NewGuid(), Name = "Charlie", GroupSize = 5 };

            await _client.PostAsync("/api/waitlist", new StringContent(JsonSerializer.Serialize(guest1), Encoding.UTF8, "application/json"));
            await _client.PostAsync("/api/waitlist", new StringContent(JsonSerializer.Serialize(guest2), Encoding.UTF8, "application/json"));

            // Act
            var response = await _client.GetAsync("/api/waitlist/queueposition/2");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("Charlie", responseContent);
        }

        [Fact]
        public async Task GetGuestsByName_ShouldReturnMatchingGuests()
        {
            // Reset the waitlist
            await _client.DeleteAsync("/api/waitlist/reset");

            // Arrange
            var guest1 = new { Id = Guid.NewGuid(), Name = "Dana", GroupSize = 2 };
            var guest2 = new { Id = Guid.NewGuid(), Name = "Dana", GroupSize = 3 };

            await _client.PostAsync("/api/waitlist", new StringContent(JsonSerializer.Serialize(guest1), Encoding.UTF8, "application/json"));
            await _client.PostAsync("/api/waitlist", new StringContent(JsonSerializer.Serialize(guest2), Encoding.UTF8, "application/json"));

            // Act
            var response = await _client.GetAsync("/api/waitlist/name/Dana");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("Dana", responseContent);
        }
    }
}
