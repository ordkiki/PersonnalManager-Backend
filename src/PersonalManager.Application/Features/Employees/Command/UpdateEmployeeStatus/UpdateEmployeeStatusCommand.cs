using MediatR;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.UpdateEmployeeStatus
{
    public record UpdateEmployeeStatusCommand : IRequest<UpdateEmployeeStatusResponse>
    {
        public required Guid EmployeeId { get; init; }
        public EmployeeStatus Status { get; set; }
    }
}
