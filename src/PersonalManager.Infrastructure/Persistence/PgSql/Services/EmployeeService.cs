using Microsoft.EntityFrameworkCore;
using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PgSqlContext _db;
        private readonly DbSet<Employee> _dbSet;
        public EmployeeService(PgSqlContext db)
        {
            _db = db;
            _dbSet = _db.Set<Employee>();
        }

        public async Task<Employee?> GetByEmailAsync(IEnumerable<string> emails)
        {
            List<Employee>? employees = await _dbSet
                .Where(e => e.Contact != null && e.Contact.Email != null)
                .ToListAsync(); // ⚠️ chargement en mémoire obligatoire car Email est un tableau

            return employees.FirstOrDefault(e =>
                e.Contact.Email.Any(email => emails.Contains(email)));
        }
    }
}
