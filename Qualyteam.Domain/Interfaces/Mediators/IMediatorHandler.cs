using Qualyteam.Domain.Events;
using System.Threading.Tasks;

namespace Qualyteam.Domain.Interfaces.Mediators
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
