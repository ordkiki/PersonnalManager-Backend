using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Interfaces.Services
{
    public interface ICodeGenerator
    {
        Task<string> SetCode(string entityName);
        Task<string> GenerateFormat(string prefix, string name, string propertyCode);
        Task<string> GenerateMatricule(string prefix, string propertyCode);
    }
}
