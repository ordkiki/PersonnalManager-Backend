using Microsoft.EntityFrameworkCore;
using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Services
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly PgSqlContext _db;
        private readonly DbSet<Department> _dbSet;
        public List<string> alphaNum = [];
        public CodeGenerator(PgSqlContext db)
        {
            _db = db;
            _dbSet = _db.Set<Department>();
        }

        public async Task<string> GenerateDepartmentCode()
        {
            List<string>? codes = await _dbSet.Select(d => d.DepartmentCode).ToListAsync();
            List<int> numericCodes = codes.Where(code => code != null && Regex.IsMatch(code, @"^\d{3}$"))
            .Select(code => int.Parse(code))
            .OrderByDescending(code => code)
            .ToList();

            int nextCode = numericCodes.Count != 0 ? numericCodes.First() + 1 : 1;
            return nextCode.ToString("{D5}");

        }

        public Task<string> GenerateFormat(string prefix, string name, string propertyCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateJobCode()
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateMatricule(string prefix, string propertyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SetCode(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new CodeException("entity name must be required", 400, false);
            int? code = 0;

          
            return "1A4";
        }
    }
}
