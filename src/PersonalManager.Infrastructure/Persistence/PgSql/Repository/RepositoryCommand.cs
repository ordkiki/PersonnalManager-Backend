using PersonaManager.Domain.Commons;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Repository
{
    public class RepositoryCommand<T> : IRepositoryCommand<T> where T : BaseEntity
    {
        public Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid? id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(Guid? id, T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}