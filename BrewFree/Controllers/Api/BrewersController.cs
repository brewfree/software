using System.Threading.Tasks;
using BrewFree.Common;
using BrewFree.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrewFree.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/brewers")]
    public class BrewersController : Controller
    {
        private readonly IBrewerService brewerService;

        public BrewersController(IBrewerService brewerService)
        {
            this.brewerService = brewerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (HttpContext.User == null)
            {
                return Unauthorized();
            }

            var brewers = await brewerService.GetListByApplicationUserAsync(HttpContext.User.GetNameIdentifierClaim());

            return Ok(brewers);
        }
    }
}