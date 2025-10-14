using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Query.GetOneDepartment
{
    public class GetOneDepartmentQueryHandler(IRepositoryQuery<Department> _repo) : IRequestHandler<GetOneDepartmentQuery, DepartmentDto>
    {
        public async Task<DepartmentDto> Handle(GetOneDepartmentQuery request, CancellationToken cancellationToken)
        {
            Department department = await _repo.FindByIdAsync(request.Id) ?? throw new Exception("No department was found");
            return new DepartmentDto
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                DepartmentCode = department.DepartmentCode,
                ParentDepartmentId = department.ParentDepartmentId
            };
        }
    }
}
