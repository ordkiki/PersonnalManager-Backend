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
        public Task<T?> FindByIdAsync(Guid id, Expression<Func<T, T>>? projection = null)
        {
            throw new NotImplementedException();
        }

        public Task<object?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<T> Data, long total, int AllPage)> FindManyAsync(Expression<Func<T, bool>> filterExpression, List<Expression<Func<T, object>>>? includes = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? limit = null, int? page = null, int? totalPage = null)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByAsync(Expression<Func<T, bool>> by, Expression<Func<T, T>>? projection = null, List<Expression<Func<T, object>>>? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>?> ListeAllWithOwner(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}