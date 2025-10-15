using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeEducation
{
    public class CreateEmployeeEducationCommandHandler(IRepositoryCommand<Employee> _repo1, IRepositoryQuery<Employee> _repo2) : IRequestHandler<CreateEmployeeEducationCommand, CreateEmployeeEducationResponse>
    {
        public async Task<CreateEmployeeEducationResponse> Handle(CreateEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _repo2.FindByIdAsync((Guid)request.EmployeeId, null) ??
                throw new ApiException("No employee was found", 400, false);

            employee.Educations.Add(new()
            {
                EmployeeId = employee.Id,
                Graduation = request.Graduation,
                Establishment = request.Establishment,
                GraduationYear = request.GraduationYear,
                FieldOfStudy = request.FieldOfStudy,
                IdChild = null
            }); 
            return new CreateEmployeeEducationResponse()
            {
                Id = (await _repo1.UpdateAsync((Guid)request.EmployeeId, employee, cancellationToken)).Id,
                Educations = employee.Educations.Select(e => new EmployeeEducation
                {
                    EmployeeId = e.EmployeeId,
                    FieldOfStudy = e.FieldOfStudy,
                    Graduation = e.Graduation,
                    GraduationYear = e.GraduationYear,
                    Establishment = e.Establishment,
                })
            };
        }
    }
}