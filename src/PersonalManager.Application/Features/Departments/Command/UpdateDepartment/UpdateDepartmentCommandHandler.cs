using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler(IRepositoryCommand<Department> _repo1, IRepositoryQuery<Department> _repo2, IUnitOfWork _unit) : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
    {
        public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department dep = await _repo2.FindByIdAsync(request.Id) ?? throw new Exception("No department was found");
            Department updatedDep = await _repo1.UpdateAsync(request.Id, dep, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);
            return new DepartmentDto
            {
                Id = updatedDep.Id,
                DepartmentName = updatedDep.DepartmentName,
                DepartmentCode = updatedDep.DepartmentCode,
                ParentDepartmentId = updatedDep.ParentDepartmentId
            };
        }
    }
}