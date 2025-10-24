using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Services
{
    public class CodeGenerator : ICodeGenerator
    {
        public Task<string> GenerateFormat(string prefix, string name, string propertyCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateMatricule(string prefix, string propertyCode)
        {
            return Task.FromResult("EMP-004");
        }

        public string SetCode(string entityName)
        {
            return "bonjour";
        }
    }
}
