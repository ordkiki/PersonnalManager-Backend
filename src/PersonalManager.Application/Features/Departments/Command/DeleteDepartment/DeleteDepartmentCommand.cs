using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
