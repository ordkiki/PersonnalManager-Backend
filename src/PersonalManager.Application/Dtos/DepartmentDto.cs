using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Dtos
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public required string DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }
        public Guid? ParentDepartmentId { get; set; }
    }
}
