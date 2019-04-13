using System.Threading.Tasks;
using Htp.BooksAPI.Domain.Contracts;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Htp.BooksAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("login/{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<UserViewModel> FindByName(string userName)
        {
            var user = userService.FindByName(userName);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserViewModel>> FindById(string id)
        {
            var user = await userService.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{id}/claims")]
        public async Task<ActionResult<bool>> ClaimsById(string id)
        {
            var user = await userService.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var claims = await userService.FindClaimsByIdAsync(id);

            return Ok(claims);
        }
    }
}


//[HttpGet]
//public IEnumerable<Product> GetAllProducts()

    /// <summary>
/// Get user by user name.
/// </summary>
/// <returns>User view model.</returns>
/// <param name="userName">The name that needs to be fetched.</param>
/// <response code="200">Successful operation</response>
/// <response code="404">User not found</response>
//[HttpGet("{username}")]
//[Route("users/{username:alpha}")]



//// GET api/users/5
//[HttpGet("{id}")]
//public ActionResult<string> Get(int id)
//{
//    return "value";
//}
// GET api/user/login

/// <summary>
/// Logs user into the system.
/// </summary>
/// <returns>The login.</returns>
/// <param name="user">User.</param>
/// <response code="200">Successful operation</response>
/// <response code="400">Invalid username/password supplied</response> 
//[HttpGet, Route("login")]
//[ProducesResponseType(200)]
//[ProducesResponseType(400)]
//public IActionResult Login(string userName, string password)
//{
//    return Ok();
//}