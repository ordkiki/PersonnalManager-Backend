using MediatR;
using PersonalManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Query.GetOneDepartment
{
    public class GetOneDepartmentQuery : IRequest<DepartmentDto>
    {
        public required Guid Id { get; set; }
    }
}
