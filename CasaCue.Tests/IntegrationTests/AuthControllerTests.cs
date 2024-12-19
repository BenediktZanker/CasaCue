using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CasaCue.Tests
{
    public class AuthControllerTests : IAsyncLifetime
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;
        private readonly List<string> _createdUsers = new(); // Speichert Benutzernamen für das Cleanup

        public AuthControllerTests(ITestOutputHelper output)
        {
            // Client konfigurieren, um mit dem Auth-Service im Docker-Container zu kommunizieren
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5002") // Docker-URL für Auth-Service
            };
            _output = output;
        }

        private StringContent CreateJsonContent(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }

        [Fact]
        public async Task RegisterUser_ReturnsOk()
        {
            var username = "testuser13";
            _createdUsers.Add(username); // Benutzername für Cleanup speichern

            // Arrange
            var user = new { username, password = "password123" };
            var content = CreateJsonContent(user);

            // Act
            var response = await _client.PostAsync("/api/auth/register", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Register Response: {response.StatusCode} - {responseString}");
            Assert.Contains("User registered", responseString);
        }

        [Fact]
        public async Task LoginUser_ReturnsToken()
        {
            var username = "testuser14";
            _createdUsers.Add(username);

            // Arrange: Benutzer registrieren
            var user = new { Username = username, Password = "password123" };
            var registerContent = CreateJsonContent(user);
            var registerResponse = await _client.PostAsync("/api/auth/register", registerContent);
            registerResponse.EnsureSuccessStatusCode();

            // Act: Benutzer einloggen
            var loginContent = CreateJsonContent(user);
            var loginResponse = await _client.PostAsync("/api/auth/login", loginContent);
            var loginResponseString = await loginResponse.Content.ReadAsStringAsync();

            _output.WriteLine($"Login Response: {loginResponse.StatusCode} - {loginResponseString}");

            // Assert
            loginResponse.EnsureSuccessStatusCode();
            Assert.Contains("Token", loginResponseString, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task RegisterUser_AlreadyExists_ReturnsBadRequest()
        {
            var username = "testuser15";
            _createdUsers.Add(username);

            // Arrange
            var user = new { username, password = "password123" };
            var content = CreateJsonContent(user);

            // Erster Aufruf: Benutzer registrieren
            await _client.PostAsync("/api/auth/register", content);

            // Act: Zweiter Aufruf
            var response = await _client.PostAsync("/api/auth/register", content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Duplicate Register Response: {response.StatusCode} - {responseString}");
            Assert.Contains("User already exists", responseString);
        }

        [Fact]
        public async Task LoginUser_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange: Benutzer mit ungültigen Daten
            var user = new { Username = "invaliduser", Password = "wrongpassword" };
            var content = CreateJsonContent(user);

            // Act
            var response = await _client.PostAsync("/api/auth/login", content);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Invalid Login Response: {response.StatusCode} - {responseString}");
            Assert.Contains("Invalid credentials", responseString);
        }

        // Cleanup-Methode für einzelne Benutzer
        private async Task CleanupUser(string username)
        {
            var response = await _client.DeleteAsync($"/api/auth/cleanup/{username}");
            _output.WriteLine($"Cleanup Response for {username}: {response.StatusCode}");
        }

        // Cleanup wird nach jedem Test aufgerufen
        public async Task DisposeAsync()
        {
            foreach (var username in _createdUsers)
            {
                await CleanupUser(username);
            }
        }

        public Task InitializeAsync() => Task.CompletedTask; // Keine Initialisierung nötig
    }
}



