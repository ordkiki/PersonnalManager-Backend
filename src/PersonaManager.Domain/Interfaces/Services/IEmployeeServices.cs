using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Employee?> GetByEmailAsync(IEnumerable<string> email);
    }
}
