using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync(CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
