using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.UpdateDepartment
{
    public class UpdateDepartmentRequest
    {
        public required string DepartmentName { get; set; }
        public Guid? ParentDepartmentId { get; set; }
    }
}
