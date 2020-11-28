using MediatR;
using Qualyteam.Domain.Events;
using Qualyteam.Domain.Interfaces.Mediators;
using System.Threading.Tasks;

namespace Qualyteam.Domain.Mediators
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
