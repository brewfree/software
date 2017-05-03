using System;
using System.Threading.Tasks;
using BrewFree.Common;
using BrewFree.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrewFree.Controllers.Api
{
    [Authorize]
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
            var brewers = await brewerService.GetListByApplicationUserAsync(HttpContext.User.GetApplicationUserId());

            return Ok(brewers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var brewer = await brewerService.GetAsync(id);

            if (brewer == null)
            {
                return NotFound();
            }

            var isOwner = string.Compare(id, HttpContext.User.GetApplicationUserId(), StringComparison.OrdinalIgnoreCase) == 0;

            if (!(isOwner || brewer.Shared))
            {
                return Unauthorized();
            }

            return Ok(brewer);
        }
    }
}