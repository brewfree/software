using System.Threading.Tasks;
using BrewFree.Data.Constants;
using BrewFree.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrewFree.Controllers.Api
{
    [Authorize(Roles = RoleType.Admin)]
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await userService.GetListAsync();

            return Ok(users);
        }
    }
}