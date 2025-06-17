public class AuthControllerTest : BaseControllerTest
    {
        public AuthControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Login_WithValidCredentials_ShouldReturnToken()
        {
            // Arrange
            var loginData = new { Nome = "admin", Senha = "admin" };

            // Act
            var response = await _client.PostAsync("/api/auth", CreateJsonContent(loginData));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(content)!;
            ((string)result.token).Should().NotBeNullOrEmpty();
        }
    }
