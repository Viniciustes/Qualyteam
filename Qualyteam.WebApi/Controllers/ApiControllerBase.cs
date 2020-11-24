using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qualyteam.Domain.Notifications;

namespace Qualyteam.WebApi.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;

        public ApiControllerBase(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        private bool IsValidOperation() =>
            !_notifications.HasNotifications();
    }
}
