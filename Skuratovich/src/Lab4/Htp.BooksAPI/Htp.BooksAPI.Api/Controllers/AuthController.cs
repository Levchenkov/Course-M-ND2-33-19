using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Htp.BooksAPI.Api.Services;
using Htp.BooksAPI.Domain.Contracts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Htp.BooksAPI.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost, Route("token")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [AllowAnonymous]
        public IActionResult Token([FromBody]ClientModel clientModel)
        {
            if (clientModel == null)
            {
                return BadRequest("Invalid client request");
            }

            clientModel = userService.Authenticate(clientModel.Username, clientModel.Password);

            if (clientModel == null)
                return Unauthorized("Username or password is incorrect");

            return Ok(clientModel);
        }
    }
}


/// <summary>
/// Login the specified loginModel.
/// </summary>
/// <returns>The login.</returns>
/// <param name="loginModel">Login model.</param>
/// <response code="200">Successful operation.</response>
/// <response code="401">Unauthorized.</response>
/// <response code="400">Invalid username/password supplied.</response>
