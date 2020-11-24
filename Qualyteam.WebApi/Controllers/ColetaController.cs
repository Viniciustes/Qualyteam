using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qualyteam.Domain.Notifications;

namespace Qualyteam.WebApi.Controllers
{
    [Route("api/coleta")]
    public class ColetaController : ApiControllerBase
    {
        public ColetaController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
        }
    }
}
