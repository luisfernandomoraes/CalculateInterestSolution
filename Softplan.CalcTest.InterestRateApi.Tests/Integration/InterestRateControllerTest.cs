using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.CalcTest.InterestRateApi.Tests.Integration
{
    public class InterestRateControllerTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InterestRateControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "Deve retornar o valor fixo de 0,01 na chamada da API")]
        public async Task should_returns_fixed_interest_rate()
        {
            // Arr

            // Act
            HttpResponseMessage response = await _client.GetAsync("/taxajuros");

            // Ass
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string responseData = response.Content.ReadAsStringAsync().Result;

            responseData.Should().NotBeEmpty();
            responseData.Should().NotBeNull();
            responseData.Should().Be("0,01");
        }
    }
}