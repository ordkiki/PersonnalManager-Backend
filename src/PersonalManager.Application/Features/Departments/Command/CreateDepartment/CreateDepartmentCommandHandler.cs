using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.CreateDepartment
{
    public class CreateDepartmentCommandHandler(IRepositoryCommand<Department> _repo, IUnitOfWork Unit, ICodeGenerator _generator) : IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        async Task<DepartmentDto> IRequestHandler<CreateDepartmentCommand, DepartmentDto>.Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department dep = new()
            {
                DepartmentName = request.DepartmentName,
                DepartmentCode = await _generator.SetCode(request.DepartmentName),
                ParentDepartmentId = request.ParentDepartmentId
            };

            await _repo.CreateAsync(dep, cancellationToken);
            await Unit.SaveChangeAsync(cancellationToken);

            return new DepartmentDto
            {
                Id = dep.Id,
                DepartmentName = dep.DepartmentName,
                DepartmentCode = dep.DepartmentCode,
                ParentDepartmentId = dep.ParentDepartmentId
            };
        }
    }
}