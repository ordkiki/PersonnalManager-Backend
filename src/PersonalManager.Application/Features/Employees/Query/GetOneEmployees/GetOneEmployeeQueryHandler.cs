using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Query.GetOneEmployees
{
    public class GetOneEmployeeQueryHandler(IRepositoryQuery<Employee> _repo2) : IRequestHandler<GetOneEmployeeQuery, GetOneEmployeeResponse>
    {
        public async Task<GetOneEmployeeResponse> Handle(GetOneEmployeeQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Employee, bool>> filter = by => true;

            Expression<Func<Employee, Employee>>? projection = null;

            List<Expression<Func<Employee, object>>>? includes = null;

            Employee employee = await _repo2.GetByAsync(by: filter, projection: projection, includes: includes);

            return new GetOneEmployeeResponse()
            {

            };    
        }
    }
}
