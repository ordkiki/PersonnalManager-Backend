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
        public Task<Employee?> GetByEmailAsync(IEnumerable<string> email)
        {
            throw new NotImplementedException();
        }
    }
}
