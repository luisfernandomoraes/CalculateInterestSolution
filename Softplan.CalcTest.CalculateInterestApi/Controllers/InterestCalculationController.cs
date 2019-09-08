using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softplan.CalcTest.CalculateInterestApi.Application;
using Softplan.CalcTest.CalculateInterestApi.Domain;
using Softplan.CalcTest.CalculateInterestApi.Infra;

namespace Softplan.CalcTest.CalculateInterestApi.Controllers
{
    
    /// <summary>
    /// Controller para cálculo de juros compostos.
    /// </summary>
    [Route("/")]
    [ApiController]
    public class InterestCalculationController : ControllerBase
    {
        private readonly ICompoundInterestService _compoundInterestService;
        private readonly ILogger<InterestCalculationController> _logger;

        /// <summary>
        /// Cria uma nova instancia 
        /// </summary>
        /// <param name="compoundInterestService"></param>
        /// <param name="logger"></param>
        public InterestCalculationController(ICompoundInterestService compoundInterestService, ILogger<InterestCalculationController> logger)
        {
            _compoundInterestService = compoundInterestService;
            _logger = logger;
        }

        /// <summary>
        /// Retorna o cálculo do valor com juros de acordo com os meses
        /// </summary>
        /// <param name="initialValue">Valor inicial</param>
        /// <param name="months">Quantidade de meses</param>
        /// <returns>Retorna o valor calculado incluindo juros de acordo com os meses</returns>
        /// <response code="200">Valor calculado incluindo juros de acordo com os meses</response>
        [HttpGet("calculajuros")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get([FromQuery(Name = "valorinicial")]
            [Required(ErrorMessage = "O parâmetro valorInicial é obrigatório")]
            decimal initialValue,
            [FromQuery(Name = "meses")]
            [Required(ErrorMessage = "O parâmetro meses é obrigatório")]
            int months)
        {
            try
            {
                var finalAmount = await _compoundInterestService.CalcAmount(initialValue, months);
                return Ok(finalAmount.Value.ToString(new CultureInfo("pt-BR")));
            }
            catch (ArgumentValueException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}