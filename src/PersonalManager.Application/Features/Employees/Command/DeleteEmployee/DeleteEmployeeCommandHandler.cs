using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler(IRepositoryCommand<Employee> _repo, IUnitOfWork _unit) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            bool result = await _repo.DeleteAsync(request.Id);
            await _unit.SaveChangeAsync(cancellationToken);
            return result;
        }
    }
}