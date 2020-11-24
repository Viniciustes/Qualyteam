using Qualyteam.Data.Contexts;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Models;

namespace Qualyteam.Data.Repositories
{
    public class IndicadorMensalRepository : Repository<IndicadorMensal>, IIndicadorMensalRepository
    {
        public IndicadorMensalRepository(QualyTeamContext context) : base(context)
        {
        }
    }
}
