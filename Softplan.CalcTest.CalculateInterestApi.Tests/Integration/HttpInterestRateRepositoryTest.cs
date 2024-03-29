﻿using System;
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
        [Fact(DisplayName = "Api deve retornar um valor válido")]
        public async Task api_should_return_valid_value()
        {
            // Arr
            var logger = Substitute.For<ILogger<InterestRateRepository>>();
            var addressFactory = Substitute.For<IServiceAddressFactory>();
            var address = new ServiceAddressFactory().Build(ConsumedServicesEnum.InterestRateApi);
            addressFactory.Build(ConsumedServicesEnum.InterestRateApi).Returns(address);
            var interestRateRepository = new InterestRateRepository(addressFactory, logger);

            // Act
            var result = await interestRateRepository.FetchCurrentInterestRate();

            // Ass
            result.Value.Should().BeOfType(typeof(decimal));
            result.Value.Should().BeGreaterThan(0);
        }
        
    }
}