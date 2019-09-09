using FluentAssertions;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class AmountTest
    {
        [Fact]
        public void should_be_valid_amount()
        {
            // Arr & Act
            const decimal valueTest = 1500.80M;
            var amount = new Amount(valueTest);

            // Ass
            amount.Value.Should().Be(valueTest);
        }

        [Fact]
        public void should_throw_argument_value_exception()
        {
            // Arr & Act & Ass
            var exception = Assert.Throws<ArgumentValueException>(() => new Amount(-42));
            exception.Message.Should().Be("Valor monetário deve ser maior ou igual a 0.");
        }
    }
}