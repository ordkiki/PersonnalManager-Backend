using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Repository
{
    public class UnitOfWork(PgSqlContext _context) : IUnitOfWork
    {
        async Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
    }
}
