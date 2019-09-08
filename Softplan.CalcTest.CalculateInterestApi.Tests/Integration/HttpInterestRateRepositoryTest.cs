using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Integration
{
    public class HttpInterestRateRepositoryTest
    {
        [Fact]
        public async Task api_should_return_valid_value()
        {
            // Arr
            var logger = Substitute.For<ILogger<HttpInterestRateRepository>>();
            var addressFactory = Substitute.For<IServiceAddressFactory>();
            addressFactory.Build(ConsumedServicesEnum.InterestRateApi).Returns(new Uri("http://interestrateapi.westus.azurecontainer.io"));
            var interestRateRepository = new HttpInterestRateRepository(addressFactory, logger);

            // Act
            var result = await interestRateRepository.FetchCurrentInterestRate();

            // Ass
            result.Value.Should().BeOfType(typeof(decimal));
            result.Value.Should().BeGreaterThan(0);
        }
        
    }
}