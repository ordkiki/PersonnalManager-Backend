using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Query.GetAllDeprtaments
{
    public class GetAllDepartmentResponse
    {
        public IEnumerable<Department> Data { get; set; }
        public int TotalPage { get; set; }
        public long Total { get; set; }
    }
}
