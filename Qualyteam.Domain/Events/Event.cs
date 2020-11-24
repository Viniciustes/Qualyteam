using MediatR;
using System;

namespace Qualyteam.Domain.Events
{
    public abstract class Event : INotification
    {
        public Event()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
    }
}
