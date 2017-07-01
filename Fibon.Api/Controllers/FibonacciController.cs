using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            return this.Content("42");
        }

        [HttpPost("{number}")]
        public IActionResult Post(int number)
        {
            return this.Accepted($"fibonacci/{number}", null);
        }
    }
}
