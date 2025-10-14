using PersonaManager.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Repository
{
    public interface IRepositoryCommand<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(Guid? id, T entity, CancellationToken cancellationToken = default);
        Task<T?> DeleteAsync(Guid? id, CancellationToken cancellationToken = default);
    }
}