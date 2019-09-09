using System;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Aggregate Root juros compostos. 
    /// </summary>
    public class CompoundInterest
    {
        /// <summary>
        /// Realiza o calculo de juros compostos com base nos seguintes parâmetros:
        /// </summary>
        /// <param name="initialAmount">Valor inicial (quantia).</param>
        /// <param name="interestRate">Taxa de juros.</param>
        /// <param name="months">Intervalo de tempo representado por quantidade de meses.</param>
        /// <returns></returns>
        public Amount Calculate(Amount initialAmount, InterestRate interestRate, Months months)
        {
            var result = initialAmount.Value * (decimal)Math.Pow(1 + (double)interestRate.Value, months.Value);
            var truncated = Math.Truncate(100 * result) / 100;
            return new Amount(truncated);
        }
    }
}