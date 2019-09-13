using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Softplan.CalcTest.CalculateInterestApi.Application;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class CompoundInterestServiceTest
    {
        [Fact(DisplayName = "Deve calcular corretamente os juros ")]
        public async Task should_calc_amount_correctly()
        {
            // Arr
            var interestRateRepository = Substitute.For<IInterestRateRepository>();
            interestRateRepository.FetchCurrentInterestRate().Returns(Task.Run(() => new InterestRate(0.01m)));
            var compoundInterestService = new CompoundInterestService(interestRateRepository);

            // Act 
            var finalAmount = await compoundInterestService.CalcAmount(100, 5);

            // Ass
            finalAmount.Value.Should().Be(105.1M);
        }
        
        [Fact(DisplayName = "No processo de cálculo o método FetchCurrentInterestRate() deve ser chamado uma vez.")]
        public async Task repository_fetch_method_should_be_called_1_time()
        {
            // Arr
            var interestRateRepository = Substitute.For<IInterestRateRepository>();
            interestRateRepository.FetchCurrentInterestRate().Returns(Task.Run(() => new InterestRate(0.01m)));
            var compoundInterestService = new CompoundInterestService(interestRateRepository);

            // Act 
            var finalAmount = await compoundInterestService.CalcAmount(100, 5);

            // Ass
            await interestRateRepository.Received(1).FetchCurrentInterestRate();
        }
    }
}