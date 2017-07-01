using System.Threading.Tasks;
using Fibon.Api.Repository;
using Fibon.Messages.Commands;
using Fibon.Messages.Events;
using RawRabbit;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {
        private readonly IRepository repository;

        public ValueCalculatedEventHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Task HandleAsync(ValueCalculatedEvent @event)
        {
            this.repository.Add(@event.Number, @event.Value);
            return Task.CompletedTask;
        }
    }
}