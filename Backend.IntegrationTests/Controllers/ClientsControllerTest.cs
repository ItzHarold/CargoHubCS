using System.Net;
using Backend.Features.Clients;
using System.Net.Http.Json;
using FluentAssertions;
using Xunit;

namespace Backend.IntegrationTests.Controllers
{
    public class ClientControllerTest
    {
        [Fact]
        public async Task GetAllClientsOnSuccessReturns200()
        {
            // Arrange
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");
            // Check out options TODO

            // Act
            var result = await client.GetAsync("http://localhost:5031/api/clients");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetClientByIdOnSuccessReturns204()
        {
            // Arrange
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");
            // Check out options TODO

            // Act
            var result = await client.GetAsync("http://localhost:5031/api/clients/1");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task AddClientOnSuccessReturns201()
        {
            // Arrange
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");


            var newclient = new Client()
            {
                Name = "New Client",
                Address = "123 Main",
                City = "Metropolis",
                ZipCode = "12345",
                Province = "Central",
                Country = "Countryland",
                ContactName = "John Doe",
                ContactPhone = "123-456-7890",
                ContactEmail = "johndoe@gmail.com"
            };


            var content = JsonContent.Create(newclient);
            // Check out options TODO

            // Act
            var result = await client.PostAsync("http://localhost:5031/api/clients", content);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateClientOnSuccessReturns204()
        {
            // Arrange
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");

            var updatedClient = new Client()
            {
                Id = 1,
                Name = "Updated Client",
                Address = "123 Main",
                City = "Metropolis",
                ZipCode = "12345",
                Province = "Central",
                Country = "Countryland",
                ContactName = "John Doe",
                ContactPhone = "123-456-7890",
                ContactEmail = "johndoe@gmail.com"
            };

            var content = JsonContent.Create(updatedClient);
            // Check out options TODO

            // Act
            var result = await client.PutAsync("http://localhost:5031/api/clients/1", content);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);

        }

        [Fact]
        public async Task DeleteClientOnSuccessReturns204()
        {
            // Arrange
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-API-KEY", "3f5e8b9c-2d4a-4b6a-8f3e-1a2b3c4d5e6f");

            // Act
            var result = await client.DeleteAsync("http://localhost:5031/api/clients/1");

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
