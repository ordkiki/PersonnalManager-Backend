using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Commons.Utils
{
    public class CodeGenerator : ICodeGenerator
    {
        public Task<string> GenerateFormat(string prefix, string name, string propertyCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateMatricule(string prefix, string propertyCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> SetCode(string entityName)
        {
            throw new NotImplementedException();
        }
    }
}
