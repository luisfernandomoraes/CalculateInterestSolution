using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalcTest.CalculateInterestApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("/")]
    [ApiController]
    public class ShowMeTheCodeController: ControllerBase
    {
        /// <summary>
        /// Retornar a url onde está o código fonte no github.
        /// </summary>
        /// <response code="200">Github Url</response>
        [HttpGet("showmethecode")]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok("https://github.com/luisfernandomoraes/CalculateInterestSolution");
        }
    }
}