using FluentValidator;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Value Object que representa a taxa de juros.
    /// </summary>
    public class InterestRate : Notifiable
    {
        /// <summary>
        /// Valor primitivo imutável após a instanciação.
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Inicializa uma instância de InterestRate.
        /// </summary>
        /// <param name="value">Valor da taxa de juros.</param>
        public InterestRate(decimal value)
        {
            if (value <= 0)
                AddNotification(nameof(Value), "Valor deve ser maior que zero.");

            Value = value;
        }
    }
}
