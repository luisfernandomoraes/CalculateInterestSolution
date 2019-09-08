using System.Threading.Tasks;
using Softplan.CalcTest.CalculateInterestApi.Domain;

namespace Softplan.CalcTest.CalculateInterestApi.Application
{
    /// <summary>
    /// Serviço de juros compostos.
    /// </summary>
    public interface ICompoundInterestService
    {
        /// <summary>
        /// Realiza o calculo de juros compostos com base nos parâmetros recebidos. 
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        Task<Amount> CalcAmount(decimal initialValue, int months);
    }
}