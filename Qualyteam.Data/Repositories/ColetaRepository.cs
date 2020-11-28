using Microsoft.EntityFrameworkCore;
using Qualyteam.Data.Contexts;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Qualyteam.Data.Repositories
{
    public class ColetaRepository : Repository<Coleta>, IColetaRepository
    {
        public ColetaRepository(QualyTeamContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Coleta>> GetAsync()
            => await _context.Coletas
                .Include(x => x.IndicadorMensal)
                .ToListAsync();

        public new async Task<Coleta> GetByIdAsync(int id)
            => await _context.Coletas
                .Include(x => x.IndicadorMensal)
                .FirstOrDefaultAsync(x => x.Id == id);

        public new async Task<IEnumerable<Coleta>> SearchAsync(Expression<Func<Coleta, bool>> expression)
            => await _context.Coletas
                .Include(x => x.IndicadorMensal).Where(expression).ToListAsync();
    }
}
