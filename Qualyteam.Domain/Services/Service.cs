using Qualyteam.Domain.Interfaces.Mediators;
using Qualyteam.Domain.Models;
using Qualyteam.Domain.Notifications;
using System.Linq;

namespace Qualyteam.Domain.Services
{
    public abstract class Service
    {
        private readonly IMediatorHandler _mediatorHandler;

        public Service(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected void NotifyValidationErrors(ModelBase model)
        {
            model.ValidationResult.Errors.ToList()
                 .ForEach(x => _mediatorHandler.RaiseEvent(new DomainNotification("Request Error", x.ErrorMessage)));
        }
    }
}
