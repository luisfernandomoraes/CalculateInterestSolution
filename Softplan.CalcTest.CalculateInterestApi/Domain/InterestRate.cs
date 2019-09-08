using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Taxa de Juros.
    /// </summary>
    public class InterestRate
    {
        public decimal Value { get; private set; }

        public InterestRate(decimal value)
        {
            if (value <= 0)
                throw new ArgumentValueException(value,"Valor deve ser maior que zero.");

            Value = value;
        }
    }
}
