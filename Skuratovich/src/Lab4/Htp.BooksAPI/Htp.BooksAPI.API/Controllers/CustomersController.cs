using System.Collections.Generic;
using Htp.BooksAPI.Common.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Htp.BooksAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILoggerManager logger;

        public CustomersController(ILoggerManager logger)
        {
            this.logger = logger;
        }

        // GET api/values
        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            logger.LogInfo($"Return all customers.");
            return new string[] { "John Doe", "Jane Doe" };
        }
    }
}
