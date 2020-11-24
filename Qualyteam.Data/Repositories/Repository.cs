using Microsoft.EntityFrameworkCore;
using Qualyteam.Data.Contexts;
using Qualyteam.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Qualyteam.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly QualyTeamContext _context;

        public Repository(QualyTeamContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
          => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(long id)
           => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> expression)
          => await _context.Set<TEntity>().Where(expression).ToListAsync();

        public async Task<int> RemoveAsync(long id)
        {
            var entity = await GetByIdAsync(id);

            _context.Set<TEntity>().Remove(entity);

            _context.SaveChanges();

            return await Task.FromResult(default(int));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
