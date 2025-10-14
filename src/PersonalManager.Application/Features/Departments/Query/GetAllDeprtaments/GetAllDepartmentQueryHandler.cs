using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Query.GetAllDeprtaments
{
    public class GetAllDepartmentQueryHandler(IRepositoryQuery<Department> _repo) : IRequestHandler<GetAllDepartmentQuery, GetAllDepartmentResponse>
    {

        public async Task<GetAllDepartmentResponse> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Department, bool>>? filter = Notactive => true;
            Expression<Func<Department, Department>>? projection = department => new Department();
            //List<Expression<Func<Department, object>>>? includes = department => department;
            filter = dep =>
              (
                  string.IsNullOrEmpty(request.Search) ||
                  (dep.DepartmentName!.ToLower().Contains(request.Search.ToLower()) ||
                   dep.DepartmentCode!.ToLower().Contains(request.Search.ToLower()))
              )

              ;


            (IEnumerable<Department> departments, long total, int allPage) = await _repo.FindManyAsync(
                filterExpression: filter,
                includes: null,
                limit: request.Limit,
                page: (request.Page != 0) ? request.Page : 1,
                orderBy: q => q.OrderByDescending(dep => dep.CreatedAt)
            );

            return  new GetAllDepartmentResponse
            {
                Data = [.. departments],
                Total = total,
                TotalPage = allPage,
            };
        }
    }
}
