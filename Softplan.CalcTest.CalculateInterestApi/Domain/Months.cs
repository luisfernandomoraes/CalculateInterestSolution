using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    public class Months
    {
        public int Value { get; private set; }

        public Months(int value)
        {
            if (value < 0)
                throw new ArgumentValueException(value,"Valor deve ser maior que zero.");

            Value = value;
        }
    }
}
