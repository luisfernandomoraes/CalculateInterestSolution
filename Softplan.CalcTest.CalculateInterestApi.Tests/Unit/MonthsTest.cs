using FluentAssertions;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class MonthsTest
    {
        [Fact]
        public void should_be_valid_month()
        {
            // Arr & Act
            const int valueTest = 18;
            var months = new Months(valueTest);

            // Ass
            months.Value.Should().Be(valueTest);
        }

        [Fact]
        public void should_throw_argument_value_exception()
        {
            // Arr & Act & Ass
            Assert.Throws<ArgumentValueException>(() => new Months(-42));
        }
    }
}