using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Value Object que representa a taxa de juros.
    /// </summary>
    public class InterestRate
    {
        /// <summary>
        /// Valor primitivo imutável após a instanciação.
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Inicializa uma instância de InterestRate.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentValueException"></exception>
        public InterestRate(decimal value)
        {
            if (value <= 0)
                throw new ArgumentValueException(value,"Valor deve ser maior que zero.");

            Value = value;
        }
    }
}
