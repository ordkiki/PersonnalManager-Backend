using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.UpdateEmployeeAvatar
{
    public class UpdateEmployeeAvatarResponse
    {
        public Guid EmployeeId { get; set; }
        public Resource Avatar { get; set; }
    }
}
