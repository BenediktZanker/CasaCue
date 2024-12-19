using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CasaCue.Tests.IntegrationTests
{
    public class WaitlistIntegrationTests : IClassFixture<WebApplicationFactory<BackendProgram>>, IAsyncLifetime
    {
        private readonly HttpClient _client;
        private readonly List<Guid> _createdGuests = new(); // Speichert erstellte Guest-IDs für Cleanup

        public WaitlistIntegrationTests(WebApplicationFactory<BackendProgram> factory)
        {
            _client = factory.CreateClient();
        }

        private StringContent CreateJsonContent(object obj) =>
            new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

        [Fact]
        public async Task AddGuest_ShouldReturnCreatedGuest()
        {
            // Arrange
            var guestId = Guid.NewGuid();
            _createdGuests.Add(guestId); // Speichere die ID für Cleanup
            var guest = new { Id = guestId, Name = "John Doe", GroupSize = 3 };
            var jsonContent = CreateJsonContent(guest);

            // Act
            var response = await _client.PostAsync("/api/waitlist", jsonContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("John Doe", content);
        }

        [Fact]
        public async Task RemoveGuest_ShouldDeleteGuest()
        {
            // Arrange
            var guestId = Guid.NewGuid();
            _createdGuests.Add(guestId);
            var guest = new { Id = guestId, Name = "Jane Doe", GroupSize = 2 };
            await _client.PostAsync("/api/waitlist", CreateJsonContent(guest));

            // Act
            var deleteResponse = await _client.DeleteAsync($"/api/waitlist/{guestId}");
            var getResponse = await _client.GetAsync($"/api/waitlist/id/{guestId}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NoContent, deleteResponse.StatusCode);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        private async Task CleanupGuest(Guid id)
        {
            await _client.DeleteAsync($"/api/waitlist/cleanup/{id}");
        }

        // Cleanup-Logik nach jedem Test
        public async Task DisposeAsync()
        {
            foreach (var guestId in _createdGuests)
            {
                await CleanupGuest(guestId);
            }
        }

        public Task InitializeAsync() => Task.CompletedTask; // Keine spezielle Initialisierung nötig
    }
}
