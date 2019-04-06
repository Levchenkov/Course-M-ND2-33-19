using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htp.BooksAPI.Common.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Htp.BooksAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggerManager logger;

        public ValuesController(ILoggerManager logger)
        {
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //logger.LogInfo("Here is info message from our values controller.");
            //logger.LogDebug("Here is debug message from our values controller.");
            //logger.LogWarn("Here is warn message from our values controller.");
            //logger.LogError("Here is error message from our values controller.");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
