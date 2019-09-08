using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Valor do montante.
    /// </summary>
    public class Amount
    {
        public decimal Value { get; private set; }

        public Amount(decimal value)
        {
            if (value < 0.0M)
                throw new ArgumentValueException(value,"Valor monetário deve ser maior ou igual a 0.");

            Value = value;
        }
    }
}
