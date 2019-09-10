using FluentValidator;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Value Object que representa o período usado no no calculo dos juros.
    /// </summary>
    public class Months : Notifiable
    {
        /// <summary>
        /// Valor primitivo imutável após a instanciação.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Inicializa uma instância de Months
        /// </summary>
        /// <param name="value">Quantidade de meses.</param>
        public Months(int value)
        {
            if (value < 0)
                AddNotification(nameof(Value), "Valor deve ser maior que zero.");

            Value = value;
        }
    }
}
