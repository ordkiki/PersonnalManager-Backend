using Microsoft.EntityFrameworkCore;
using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;
using PersonaManager.Domain.Commons;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Repository
{
    public class RepositoryQuery<T> : IRepositoryQuery<T> where T : BaseEntity
    {
        private readonly PgSqlContext _db;
        private readonly DbSet<T> _dbSet;
        public RepositoryQuery(PgSqlContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken, Expression<Func<T, T>>? projection = null)
        {
            if (projection != null)
            {
                 return await _dbSet.Where(x => x.Id == id).Select(projection).FirstOrDefaultAsync(cancellationToken);
            }

            return await _dbSet.FindAsync(id);
        }

        public async Task<(IEnumerable<T> Data, long total, int AllPage)> FindManyAsync(
            Expression<Func<T, bool>>? filterExpression,
            List<Expression<Func<T, object>>>? includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? limit = null,
            int? page = null,
            int? totalPage = null
        )
        {
            IQueryable<T> query = _dbSet.Where(filterExpression);

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            long total = await query.LongCountAsync();
            totalPage = ((int)total / limit) + 1 ?? 0;

            if (limit.HasValue && page.HasValue)
            {
                int skip = (page.Value - 1) * limit.Value;
                query = query.Skip(skip).Take(limit.Value);
            }

            List<T> data = await query.ToListAsync();
            return (data, total, (int)totalPage);
        }

        public async Task<T?> GetByAsync(Expression<Func<T, bool>> by, Expression<Func<T, T>>? projection = null, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _dbSet.Where(by);
            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }
            if (projection != null)
            {
                return await _dbSet.Where(by).Select(projection).FirstOrDefaultAsync();
            }
            return await _dbSet.FirstOrDefaultAsync(by);
            
        }

        public Task<IEnumerable<T>?> ListeAllWithOwner(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}