using System.Linq;
using FluentAssertions;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class InterestRateTest
    {
        [Fact(DisplayName = "Valor de taxa de juros válido")]
        public void should_be_valid_interest_rate_valid()
        {
            // Arr & Act
            const decimal valueTest = 0.02M;
            var interestRate = new InterestRate(valueTest);

            // Ass
            interestRate.Value.Should().Be(valueTest);
            interestRate.Valid.Should().BeTrue();
        }

        [Fact(DisplayName = "Retornar uma notificação de valor inválido")]
        public void should_throw_argument_value_exception()
        {
            // Arr & Act
            var interestRate = new InterestRate(-0.02M);

            // Ass
            interestRate.Valid.Should().BeFalse();
            interestRate.Notifications.Count.Should().Be(1);
            interestRate.Notifications.First().Message.Should().Be("Valor deve ser maior que zero.");
        }
    }
}