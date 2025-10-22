using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.ValuesObject;
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

            filter = employee =>

               (
                    string.IsNullOrEmpty(request.Term) ||
                    (
                        employee.Matricule!.Contains(request.Term!, StringComparison.CurrentCultureIgnoreCase) ||
                        employee.Id.ToString()!.Equals(request.Term!, StringComparison.CurrentCultureIgnoreCase) ||
                        employee.Identity!.FirstName!.Contains(request.Term!, StringComparison.CurrentCultureIgnoreCase) ||
                        employee.Identity!.LastName!.Contains(request.Term!, StringComparison.CurrentCultureIgnoreCase) ||
                        employee.Identity.Gender.ToString()!.Contains(request.Term!, StringComparison.CurrentCultureIgnoreCase) ||
                        employee.Status.ToString()!.Contains(request.Term!, StringComparison.CurrentCultureIgnoreCase) ||
                        employee.CreatedAt.ToString().Contains(request.Term!, StringComparison.CurrentCultureIgnoreCase)
                    )
               )
               
            ;

            List<Expression<Func<Employee, object?>>> inc = new()
            {
                e => e.Banks,
                e => e.Contracts,
                e => e.Educations,
                e => e.Children,
                e => e.Job
            };

            Expression<Func<Employee, Employee>>? projection = null;


            Employee employee = await _repo2.GetByAsync(by: filter, projection: projection, includes: inc ?? null) ?? throw new ApiException("no employee was found", 400, false);

            return new GetOneEmployeeResponse()
            {
                Identity = employee.Identity,

                Adress = new Adress()
                {
                    Area = employee?.Adress?.Area,
                    City = employee?.Adress?.City,
                    Country = employee?.Adress?.Country,
                    District = employee?.Adress?.District,
                    PostalCode = employee?.Adress?.PostalCode,
                    Region = employee?.Adress?.Region,
                    Street = employee?.Adress?.Street,

                },
                JobTitle = employee?.Job?.JobTitle,
                ManagerName = employee?.Manager?.Identity?.FirstName,
                Banks = employee?.Banks?.Select(b => new EmployeeBanksResponse()
                {
                    AccountLabel = b.AccountLabel,
                    Bic = b.Bic,
                    CountryCode = b.CountryCode,
                    Iban = b.Iban,
                    Id = b.Id,
                    Rib = b.Rib,
                    
                }).ToList(),

                Contracts = employee.Contracts.Select(c => new EmployeeContractsResponse()
                {
                    ContratReference = c.ContratReference,
                    EndDate = c.EndDate,
                    Id = c.Id,
                    IsActive = c.IsActive,
                    SalaryMensual = c.SalaryMensual,
                    StartDate = c.StartDate,
                    TypeContract = c.TypeContrat.ToString(),
                   
                }).ToList(),
            };    
        }
    }
}
