using System.Linq;
using FluentAssertions;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class MonthsTest
    {
        [Fact(DisplayName = "Valor para meses válido")]
        public void should_be_valid_month()
        {
            // Arr & Act
            const int valueTest = 18;
            var months = new Months(valueTest);

            // Ass
            months.Value.Should().Be(valueTest);
            months.Valid.Should().BeTrue();
        }

        [Fact(DisplayName = "Retornar uma notificação de valor inválido")]
        public void should_be_invalid_value_with_one_notification()
        {
            // Arr & Act 
            var months = new Months(-42);

            // Ass
            months.Valid.Should().BeFalse();
            months.Notifications.Count.Should().Be(1);
            months.Notifications.First().Message.Should().Be("Valor deve ser maior que zero.");
        }
    }
}