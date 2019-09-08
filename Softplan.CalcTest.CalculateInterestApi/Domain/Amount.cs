using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Value Object que representa valor monetário usado no domínio da aplicação.
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// Valor primitivo imutável após a instanciação.
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// Inicializa uma instância de Amount.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentValueException"></exception>
        public Amount(decimal value)
        {
            if (value < 0.0M)
                throw new ArgumentValueException(value,"Valor monetário deve ser maior ou igual a 0.");

            Value = value;
        }
    }
}
