using System.Threading.Tasks;
using Softplan.CalcTest.CalculateInterestApi.Domain;

namespace Softplan.CalcTest.CalculateInterestApi.Application
{
    /// <summary>
    /// TODO: Descrever
    /// </summary>
    public class CompoundInterestService: ICompoundInterestService
    {
        private readonly IHttpInterestRateRepository _httpInterestRateRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpInterestRateRepository"></param>
        public CompoundInterestService(IHttpInterestRateRepository httpInterestRateRepository)
        {
            _httpInterestRateRepository = httpInterestRateRepository;
        }


        /// <summary>
        /// TODO: Descrever
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public async Task<Amount> CalcAmount(decimal initialValue, int months)
        {
            var compoundInterest = new CompoundInterest();
            var interestRate = await GetInterestRate();
            var finalValue = compoundInterest.Calculate(new Amount(initialValue), interestRate, new Months(months));
            return finalValue;
        }


        /// <summary>
        /// TODO: Descrever
        /// </summary>
        /// <returns></returns>
        private async Task<InterestRate> GetInterestRate()
        {
            InterestRate interestRate = await _httpInterestRateRepository.FetchCurrentInterestRate();
            return interestRate;
        }
    }
}