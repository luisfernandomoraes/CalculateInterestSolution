using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Integration
{
    public class InterestCalculationControllerTest: BaseTests, IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InterestCalculationControllerTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("0", "0")]
        [InlineData("100", "5")]
        [InlineData("100.01", "5")]
        public async Task should_returns_ok_for_valid_values(string value, string months)
        {
            // Arr
            string queryString = CreateQueryString(value, months);

            // Act
            var response = await _client.GetAsync("/calculajuros" + queryString);

            // Ass
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            string responseData = response.Content.ReadAsStringAsync().Result;
            responseData.Should().NotBeEmpty();
            responseData.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "1")]
        [InlineData("1", null)]
        [InlineData("", "")]
        [InlineData("", "-3")]
        [InlineData("something", "5")]
        public async Task should_returns_badRequest_for_invalid_values(string value, string months)
        {
            // Arr
            string queryString = CreateQueryString(value, months);

            // Act
            HttpResponseMessage response = await _client.GetAsync("/calculajuros" + queryString);

            // Ass
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest, "");
        }
    }
}