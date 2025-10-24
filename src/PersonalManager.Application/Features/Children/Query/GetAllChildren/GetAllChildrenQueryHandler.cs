using MediatR;
using PersonalManager.Application.Features.Children.Command.CreateChildEducation;
using PersonalManager.Application.Features.Employees.Query.GetAllEmployees;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Query.GetAllChildren
{
    public class GetAllChildrenQueryHandler(IRepositoryQuery<Child> _repo) : IRequestHandler<GetAllChildrenQuery, GetAllChildResponse>
    {
        public async Task<GetAllChildResponse> Handle(GetAllChildrenQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Child, bool>> filter = e => true;

            filter = employee =>

               (
                    string.IsNullOrEmpty(request.Search) ||
                    (
                        employee.Identity!.FirstName!.Contains(request.Search!) ||
                        employee.Identity!.LastName!.Contains(request.Search!) ||
                        employee.Identity.Gender.ToString()!.Contains(request.Search!) ||
                        employee.CreatedAt.ToString().Contains(request.Search!)
                    )
               )
               &&
               (
                   
                   (employee.IsDependent == request.Dependent)
               )
            ;

            List<Expression<Func<Child, object>>> includes = new()
            {
                e => e.Educations,
                e => e.Employee
            };

            Expression<Func<Child, object>> orderBy = request.OrderBy switch
            {
                _ => e => e.CreatedAt
            };

            Expression<Func<Child, Child>> projection = e => null;

            (IEnumerable<Child> data, long total, int allPage) = await _repo.FindManyAsync(
                filterExpression: filter,
                includes: includes,
                orderBy: request.SortazAZ == true ? q => q.OrderBy(orderBy) : q => q.OrderByDescending(orderBy),
                limit: request.Limit,
                page: request.Page

            );

            return new GetAllChildResponse()
            {
                Total = total,
                Data = data.Select(c => new ChildrenResponse
                {
                    IsDependent = c.IsDependent,
                    BirthDate = c.Identity?.BirthDate,
                    BirthPlace = c.Identity?.BirthPlace,
                    FirstName = c.Identity?.FirstName,
                    LastName = c.Identity?.LastName,
                    Gender = c.Identity?.Gender,
                    Nationality = c.Identity?.Nationality,
                    ParentName = c.Employee!.Identity!.FirstName,
                    Profil = c.Identity?.Avatar ?? null,
                    Id = c.Id,
                    Educations = c.Educations?.Select(e => new ChildEdcation
                    {
                        Establishment = e.Establishment,
                        FieldOfStudy = e.FieldOfStudy,
                        Graduation = e.Graduation,
                        GraduationYear = e.GraduationYear
                    }).ToList() ?? [],

                }).ToList() ?? [],
                TotalPage = allPage,
            };
        }
    }
}
