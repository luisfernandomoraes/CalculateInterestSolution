using Microsoft.AspNetCore.Mvc;

namespace Softplan.CalcTest.CalculateInterestApi.Controllers
{
    /// <summary>
    /// Controller para exibir a url do código fonte do projeto.
    /// </summary>
    [Route("/")]
    [ApiController]
    public class ShowMeTheCodeController: ControllerBase
    {
        /// <summary>
        /// Retornar a url onde está o código fonte do projeto no Github.
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