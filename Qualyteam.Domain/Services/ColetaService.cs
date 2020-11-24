using Qualyteam.Application.Interfaces;
using Qualyteam.Domain.Interfaces.Mediators;

namespace Qualyteam.Domain.Services
{
    public class ColetaService : Service, IColetaService
    {
        public ColetaService(IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
        }
    }
}
