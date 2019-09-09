using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Value Object que representa o período usado no no calculo dos juros.
    /// </summary>
    public class Months
    {
        /// <summary>
        /// Valor primitivo imutável após a instanciação.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Inicializa uma instância de Months
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentValueException"></exception>
        public Months(int value)
        {
            if (value < 0)
                throw new ArgumentValueException(value,"Valor deve ser maior que zero.");

            Value = value;
        }
    }
}
