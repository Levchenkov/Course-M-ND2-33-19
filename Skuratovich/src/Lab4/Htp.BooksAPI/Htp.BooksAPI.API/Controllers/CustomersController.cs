using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Htp.BooksAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            this.logger = logger;
        }

        // dotnet new mvc -o moviemvc --auth Individual

        // GET api/values
        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            logger.LogInformation($"Return all customers.");
            return new string[] { "John Doe", "Jane Doe" };
        }
    }
}
