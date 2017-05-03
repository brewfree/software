using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BrewFree.Controllers.Api
{
    [Route("api/styles")]
    public class StylesController : Controller
    {
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return null;
        }
    }
}
