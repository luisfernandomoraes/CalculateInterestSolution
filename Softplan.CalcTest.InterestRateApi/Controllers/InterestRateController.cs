using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalcTest.InterestRateApi.Controllers
{
    /// <summary>
    /// Controller para taxa de juros.
    /// </summary>
    [Route("/")]
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        /// <summary>
        /// Retorna o valor da taxa de juros.
        /// </summary>
        /// <returns>Retorna o valor da taxa de juros. </returns>
        [HttpGet("taxajuros")]
        [ProducesResponseType(200)]
        public IActionResult GetInterestRate()
        {
            return Ok(Domain.InterestRate.RateValue.ToString(new CultureInfo("pt-BR")));
        }
    }
}