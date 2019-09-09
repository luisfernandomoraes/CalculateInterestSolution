using System.Threading.Tasks;

namespace Softplan.CalcTest.CalculateInterestApi.Domain
{
    /// <summary>
    /// Contrato de repositório que é requisito de infraestrutura do domínio.
    /// </summary>
    public interface IInterestRateRepository
    {
        /// <summary>
        /// Busca a taxa de juros de outro domínio.
        /// </summary>
        /// <returns></returns>
        Task<InterestRate> FetchCurrentInterestRate();
    }
}
