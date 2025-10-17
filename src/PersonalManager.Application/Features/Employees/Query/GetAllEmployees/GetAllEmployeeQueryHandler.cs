using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Query.GetAllEmployees
{
    public class GetAllEmployeeQueryHandler(IRepositoryQuery<Employee> _repo) : IRequestHandler<GetAllEmployeeQuery, GetAllEmployeeQueryResponse>
    {
        public async Task<GetAllEmployeeQueryResponse> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Employee, bool>> filter = e => true;


            List<Expression<Func<Employee, object>>> includes = new ()
            {
                e => e.Banks,
                e => e.Contracts,
                e => e.Educations,
                e => e.Children,
                e => e.Job
            };

            Expression<Func<Employee, object>> orderBy = request.OrderBy switch
            {
                "Matricule" => e => e.Matricule!,
                "Status" => e => e.Status!,
                "LastName" => e => e.Identity!.LastName!,
                "FirstName" => e => e.Identity!.FirstName!,
                "BirthDate" => e => e.Identity!.BirthDate!,
                _ => e => e.CreatedAt
            };

            Expression<Func<Employee, Employee>> projection = e => null;

            (IEnumerable<Employee> data, long total, int allPage) = await _repo.FindManyAsync(
                filterExpression: filter,
                includes: includes,
                orderBy: request.SortazAZ == true ? q => q.OrderBy(orderBy) : q => q.OrderByDescending(orderBy),
                limit: request.Limit,
                page: request.Page
                
            );

            return new GetAllEmployeeQueryResponse()
            {
                Total = total,
                TotalPage = allPage,
                Data = data.ToList() ?? [],
            };
        }
    }
}