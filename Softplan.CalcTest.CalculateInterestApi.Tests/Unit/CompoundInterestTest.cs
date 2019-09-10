using FluentAssertions;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class CompoundInterestTest
    {
        [Fact(DisplayName = "Deve calcular corretamente o valor dos juros compostos")]
        public void should_calculate_correctly_interest_value()
        {
            // Arr
            var compoundInterest = new CompoundInterest();
            var months = new Months(5);
            var interestRate = new InterestRate(0.01M);
            var amount = new Amount(100.00M);

            // Act
            var finalAmount = compoundInterest.Calculate(amount, interestRate, months);

            // Ass
            finalAmount.Value.Should().Be(105.10M);

        }

        [Fact(DisplayName = "Deve retornar zero se o valor inicial for zero")]
        public void should_return_zero_value_if_amount_is_zero()
        {
            // Arr
            var compoundInterest = new CompoundInterest();
            var months = new Months(5);
            var interestRate = new InterestRate(0.01M);
            var amount = new Amount(0.00M);

            // Act
            var finalAmount = compoundInterest.Calculate(amount, interestRate, months);

            // Ass
            finalAmount.Value.Should().Be(0);
        }
    }
}