using System.Linq;
using FluentAssertions;
using NSubstitute.Routing.Handlers;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;
using Xunit;

namespace Softplan.CalcTest.CalculateInterestApi.Tests.Unit
{
    public class AmountTest
    {
        [Fact(DisplayName = "Valor monetário válido")]
        public void should_be_valid_amount()
        {
            // Arr & Act
            const decimal valueTest = 1500.80M;
            var amount = new Amount(valueTest);


            // Ass
            amount.Valid.Should().BeTrue();
            amount.Value.Should().Be(valueTest);
        }

        [Fact(DisplayName = "Retornar uma notificação de valor inválido")]
        public void should_be_invalid_value_with_one_notification()
        {
            // Arr & Act
            var amount = new Amount(-42);

            // Ass
            amount.Valid.Should().BeFalse();
            amount.Notifications.Count.Should().Be(1);
            amount.Notifications.First().Message.Should().Be("Valor monetário deve ser maior ou igual a 0.");
        }
    }
}