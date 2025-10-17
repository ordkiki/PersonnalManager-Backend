using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.UpdateEmployeeStatus
{
    public class UpdateEmployeeStatusCommandHandler(IRepositoryCommand<Employee> _repo, IRepositoryQuery<Employee> _repo2, IUnitOfWork _unit) : IRequestHandler<UpdateEmployeeStatusCommand, UpdateEmployeeStatusResponse>
    {
        public async Task<UpdateEmployeeStatusResponse> Handle(UpdateEmployeeStatusCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _repo2.FindByIdAsync((Guid)request.EmployeeId, null) ??
   throw new ApiException("No employee was found", 400, false);

            employee.Status = request.Status;

            Employee? updatedEmployee = await _repo.UpdateAsync(request.EmployeeId, employee);
            await _unit.SaveChangeAsync(cancellationToken);

            return new UpdateEmployeeStatusResponse
            {
                EmployeeId = updatedEmployee.Id,
                Status = updatedEmployee.Status.ToString()
            };
        }
    }
}