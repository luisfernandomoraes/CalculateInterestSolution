using FluentAssertions;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class InterestRateTest
    {
        [Fact]
        public void should_be_valid_month()
        {
            // Arr & Act
            const decimal valueTest = 0.02M;
            var interestRate = new InterestRate(valueTest);

            // Ass
            interestRate.Value.Should().Be(valueTest);
        }

        [Fact]
        public void should_throw_argument_value_exception()
        {
            // Arr & Act & Ass
            Assert.Throws<ArgumentValueException>(() => new InterestRate(-0.02M));
        }
    }
}