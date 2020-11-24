using Qualyteam.Data.Contexts;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Models;

namespace Qualyteam.Data.Repositories
{
    public class ColetaRepository : Repository<Coleta>, IColetaRepository
    {
        public ColetaRepository(QualyTeamContext context) : base(context)
        {
        }
    }
}
