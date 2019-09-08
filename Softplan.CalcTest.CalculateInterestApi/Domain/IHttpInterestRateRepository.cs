using System.Threading.Tasks;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IHttpInterestRateRepository
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Task<InterestRate> FetchCurrentInterestRate();
    }
}
