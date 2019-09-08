using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Softplan.CalcTest.CalculateInterestApi.Application;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class CompoundInterestServiceTest
    {
        [Fact]
        public async Task should_calc_amount_correctly()
        {
            // Arr
            var interestRateRepository = Substitute.For<IHttpInterestRateRepository>();
            interestRateRepository.FetchCurrentInterestRate().Returns(Task.Run(() => new InterestRate(0.01m)));
            var compoundInterestService = new CompoundInterestService(interestRateRepository);

            // Act 
            var finalAmount = await compoundInterestService.CalcAmount(100, 5);

            // Ass
            finalAmount.Value.Should().Be(105.1M);
        }
        
        [Fact]
        public async Task repository_fetch_method_should_be_called_1_time()
        {
            // Arr
            var interestRateRepository = Substitute.For<IHttpInterestRateRepository>();
            interestRateRepository.FetchCurrentInterestRate().Returns(Task.Run(() => new InterestRate(0.01m)));
            var compoundInterestService = new CompoundInterestService(interestRateRepository);

            // Act 
            var finalAmount = await compoundInterestService.CalcAmount(100, 5);

            // Ass
            await interestRateRepository.Received(1).FetchCurrentInterestRate();
        }
    }
}