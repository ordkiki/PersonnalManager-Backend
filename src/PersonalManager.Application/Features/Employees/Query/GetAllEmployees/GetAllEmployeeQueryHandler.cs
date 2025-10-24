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
            Expression<Func<Employee, bool>> filter = employee => true;

            filter = employee =>
               (
                    string.IsNullOrEmpty(request.Search) ||
                    (employee.Identity.FirstName != null && employee.Identity.FirstName.ToLower().Contains(request.Search.ToLower())) ||
                    (employee.Identity.LastName != null && employee.Identity.LastName.ToLower().Contains(request.Search.ToLower()))
               )
               &&
               (
                    string.IsNullOrEmpty(request.JobTitle) ||
                    (employee.Job != null && employee.Job.JobTitle == request.JobTitle)
               )
               &&
               (
                    (request.Status == null) ||
                    (employee.Status != null && employee.Status == request.Status)
               )
            ;

            List<Expression<Func<Employee, object?>>> includes = new()
            {
                e => e.Educations,
                e => e.Banks,
                e => e.Children,
                e => e.Contracts,
                e => e.Job,
                e => e.Manager
            };

            (IEnumerable<Employee> result, long total, int allPage) = await _repo.FindManyAsync(
                filterExpression:  filter,
                includes,
                limit: request.Limit,
                page: request.Page,
                orderBy: q => q.OrderByDescending(dep => dep.CreatedAt));



            return new GetAllEmployeeQueryResponse()
            {
                Total = total,
                TotalPage = allPage,
                Data = result.Select(personnal => new EmployeeInformationResponse
                {
                    Id = personnal.Id,
                    Matricule = personnal.Matricule,
                    Identity = personnal.Identity,
                    Adress = personnal.Adress,
                    CivilStatus = personnal.CivilStatus,
                    Contact = personnal.Contact,
                    Banks = personnal.Banks?.Select(b => new EmployeeBank
                    {
                        Id = b.Id,
                        Rib = b.Rib,
                        Iban = b.Iban,
                        CountryCode = b.CountryCode,
                        Bic = b.Bic,
                        AccountLabel = b.AccountLabel
                    }).ToList() ?? [],

                    Contracts = personnal.Contracts?.Select(b => new EmployeeContract
                    {
                        Id = b.Id,
                        ContratReference = b.ContratReference,
                        StartDate = b.StartDate,
                        SalaryMensual = b.SalaryMensual,
                        EndDate = b.EndDate,
                        TypeContrat = b.TypeContrat,
                        IsActive = b.IsActive
                    }).ToList() ?? [],

                    Educations = personnal.Educations?.Select(e => new EmployeeEducation
                    {
                        Id = e.Id,
                        Establishment = e.Establishment,
                        FieldOfStudy = e.FieldOfStudy,
                        Graduation = e.Graduation,
                        GraduationYear = e.GraduationYear,
                    }).ToList() ?? [],

                    Children = personnal.Children?.Select(c => new EmployeeChild
                    {
                        Id = c.Id,
                        Identity = c.Identity,

                        IsDependent = c.IsDependent,
                    }).ToList() ?? [],

                    Status = personnal.Status,
                    JobTitle = personnal.Job?.JobTitle,

                    ManagerName = personnal.ManagerId != null ? personnal.Manager?.Identity?.FirstName : string.Empty
                }).ToList() ?? []
            };
        }
    }
}