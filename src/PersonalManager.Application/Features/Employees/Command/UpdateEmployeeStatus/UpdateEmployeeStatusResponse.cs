using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.UpdateEmployeeStatus
{
    public class UpdateEmployeeStatusResponse
    {
        public required Guid EmployeeId { get; set; }
        public string Status { get; set; }
    }
}
