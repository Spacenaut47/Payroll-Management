using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PayrollManagement.API;
using PayrollManagement.Core.DTOs.Auth;
using Xunit;

namespace PayrollManagement.Tests
{
    public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_ShouldReturnToken_ForValidCredentials()
        {
            // Arrange
            var login = new LoginRequestDto
            {
                Username = "admin",
                Password = "Admin@123"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", login);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var body = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResponseDto>>();
            body.Should().NotBeNull();
            body!.Success.Should().BeTrue();
            body.Data!.Token.Should().NotBeNullOrEmpty();
        }
    }
}
