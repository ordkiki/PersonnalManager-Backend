using Microsoft.EntityFrameworkCore.Query;
using PersonaManager.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Repository
{
    public interface IRepositoryQuery<T> where T : BaseEntity
    {
        Task<(IEnumerable<T> Data, long total, int AllPage)> FindManyAsync(
            Expression<Func<T, bool>> filterExpression,
            List<Expression<Func<T, object>>>? includes = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? limit = null,
            int? page = null,
            int? totalPage = null
        );
        Task<T?> GetByAsync(Expression<Func<T, bool>> by, Expression<Func<T, T>>? projection = null, List<Expression<Func<T, object>>>? includes = null);
       Task<T?> FindByIdAsync(Guid id, Expression<Func<T, T>>? projection = null);
        Task<IEnumerable<T>?> ListeAllWithOwner(Expression<Func<T, bool>> filter);
        Task<object?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}