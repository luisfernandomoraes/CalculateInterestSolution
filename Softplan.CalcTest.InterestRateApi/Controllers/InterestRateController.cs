using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalcTest.InterestRateApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        /// <summary>
        /// Retorna o valor da taxa de juros.
        /// </summary>
        /// <returns>Retorna o valor da taxa de juros. </returns>
        [HttpGet("taxaJuros")]
        [ProducesResponseType(200)]
        public IActionResult GetInterestRate()
        {
            return Ok(Domain.InterestRate.RateValue);
        }
    }
}