using System.Threading.Tasks;
using Softplan.CalcTest.CalculateInterestApi.Domain;

namespace Softplan.CalcTest.CalculateInterestApi.Application
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompoundInterestService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        Task<Amount> CalcAmount(decimal initialValue, int months);
    }
}