using MediatR;
using PersonalManager.Application.Features.Employees.Command.DeleteEmployee;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.DeletePartialEmployee
{
    public class DeletePartialEmployeeCommandHandler(IRepositoryCommand<Employee> _repo, IRepositoryQuery<Employee> _repo2, IUnitOfWork _unit) : IRequestHandler<DeletePartialEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeletePartialEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _repo2.FindByIdAsync(request.Id, cancellationToken) ?? throw new ApiException("no employee was found", 400, false);
            employee.IsDeleted = true;
            await _repo.UpdateAsync(request.Id, employee, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}