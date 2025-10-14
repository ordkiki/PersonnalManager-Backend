using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler(IRepositoryCommand<Department> _repo, IRepositoryQuery<Department> _repo2, IUnitOfWork _unit) : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department? dep = await _repo2.FindByIdAsync(request.Id) ?? throw new ApiException("no department was found", 400, false);
            bool? x = await _repo.DeleteAsync(request.Id, cancellationToken);
            if (x == true)
            {
                await _unit.SaveChangeAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
