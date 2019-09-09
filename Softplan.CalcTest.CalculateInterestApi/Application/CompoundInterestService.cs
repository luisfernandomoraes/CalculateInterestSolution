using System.Threading.Tasks;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Application
{
    /// <inheritdoc />
    public class CompoundInterestService: ICompoundInterestService
    {
        private readonly IInterestRateRepository _interestRateRepository;

        /// <summary>
        /// Inicializa uma instância de CompoundInterestService.
        /// </summary>
        /// <param name="interestRateRepository"></param>
        public CompoundInterestService(IInterestRateRepository interestRateRepository)
        {
            _interestRateRepository = interestRateRepository;
        }


        /// <inheritdoc />
        public async Task<Amount> CalcAmount(decimal initialValue, int months)
        {
            var compoundInterest = new CompoundInterest();
            var interestRate = await GetInterestRate();
            var finalValue = compoundInterest.Calculate(new Amount(initialValue), interestRate, new Months(months));
            return finalValue;
        }


        /// <summary>
        /// Faz a busca do valor atual da taxa de juros.
        /// </summary>
        /// <returns></returns>
        private async Task<InterestRate> GetInterestRate()
        {
            InterestRate interestRate = await _interestRateRepository.FetchCurrentInterestRate();
            return interestRate;
        }
    }
}