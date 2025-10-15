using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Query.GetAllEmployees
{
    public class GetAllEmployeeQueryResponse
    {
        public IEnumerable<Employee>? Data { get; set; }
        public long? Total { get; set; }
        public int? TotalPage { get; set; }
    }
}