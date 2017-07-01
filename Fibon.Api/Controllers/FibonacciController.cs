using System.Threading.Tasks;
using Fibon.Api.Frameworks;
using Fibon.Api.Repository;
using Fibon.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RawRabbit;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IBusClient busClient;
        private readonly IRepository repository;

        public FibonacciController(IBusClient busClient, IRepository repository)
        {
            this.busClient = busClient;
            this.repository = repository;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            int? calculatedValue = this.repository.Get(number);
            if (calculatedValue.HasValue)
            {
                return this.Content(calculatedValue.ToString());
            }

            return this.NotFound();
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            int? calculatedValue = this.repository.Get(number);
            if (!calculatedValue.HasValue)
            {
                await this.busClient.PublishAsync(new CalculateValueCommand(number));
            }

            return this.Accepted($"fibonacci/{number}", null);
        }
    }
}