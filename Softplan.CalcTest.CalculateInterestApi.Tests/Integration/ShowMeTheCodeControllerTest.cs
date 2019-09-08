using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Integration
{
    public class ShowMeTheCodeControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ShowMeTheCodeControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task should_returns_project_url_github()
        {
            // Arr

            // Act
            HttpResponseMessage response = await _client.GetAsync("/showmethecode");

            // Ass
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string responseData = response.Content.ReadAsStringAsync().Result;
            responseData.Should().NotBeEmpty();
            responseData.Should().NotBeNull();
            responseData.Should().Contain("github.com");
            responseData.Should().Contain("luisfernandomoraes/CalculateInterestSolution");
        }
    }
}