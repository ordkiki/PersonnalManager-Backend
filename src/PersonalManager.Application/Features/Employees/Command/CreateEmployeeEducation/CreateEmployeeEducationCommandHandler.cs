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
    public class CreateEmployeeEducationCommandHandler(IRepositoryCommand<Employee> _repo1, IRepositoryCommand<Education> _educationRepo, IRepositoryQuery<Employee> _repo2, IUnitOfWork _unit) : IRequestHandler<CreateEmployeeEducationCommand, CreateEmployeeEducationResponse>
    {
        public async Task<CreateEmployeeEducationResponse> Handle(CreateEmployeeEducationCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _repo2.FindByIdAsync((Guid)request.EmployeeId, null) ??
                throw new ApiException("No employee was found", 400, false);

            await _educationRepo.CreateAsync(employee.Educations.Last(), cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);

            return new CreateEmployeeEducationResponse()
            {
                Education =  new EmployeeEducation
                {
                    EmployeeId = request.EmployeeId,
                    FieldOfStudy = request.FieldOfStudy,
                    Graduation = request.Graduation,
                    GraduationYear = request.GraduationYear,
                    Establishment = request.Establishment,
                }
            };
        }
    }
}