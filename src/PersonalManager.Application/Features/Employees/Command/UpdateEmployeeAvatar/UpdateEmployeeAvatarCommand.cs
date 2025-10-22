using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.UpdateEmployeeAvatar
{
    public class UpdateEmployeeAvatarCommand : IRequest<UpdateEmployeeAvatarResponse>
    {
        public required Guid EmployeeId { get; set; }
        public required IFormFile Avatar {  get; set; }
    }
}
