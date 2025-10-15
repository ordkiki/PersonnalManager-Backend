using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using PersonaManager.Domain.ValuesObject;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeIdentity
{
    public class CreateEmployeeIdentityCommandHandler(IRepositoryCommand<Employee> _repo, IRepositoryQuery<Employee> _repo2, IUnitOfWork _unit, IFileService _file) : IRequestHandler<CreateEmployeeIdentityCommand, CreateEmployeeIdentityResponse>
    {
        public async Task<CreateEmployeeIdentityResponse> Handle(CreateEmployeeIdentityCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _repo2.FindByIdAsync((Guid)request.EmployeeId, null) ??
    throw new ApiException("No employee was found", 400, false);

            employee.Identity = new Identity()
            {
                LastName = request.LastName ?? employee.Identity!.LastName,
                FirstName = request.FirstName ?? employee.Identity?.FirstName,
                BirthDate = request.BirthDate ?? employee.Identity!.BirthDate,
                BirthPlace = request.BirthPlace ?? employee.Identity!.BirthPlace,
                Gender = request.Gender ?? employee.Identity?.Gender,
                CIN = request.CIN,
                Nationality = request.Nationality ?? employee.Identity?.Nationality,
            };

            if (request.Image is null)
                employee.Identity.Avatar = null;
            else
                employee.Identity.Avatar = await _file.UploadAsync(request.Image!, "images/employee") ?? null;

            Employee? updatedEmployee = await _repo.UpdateAsync(request.EmployeeId, employee);
            await _unit.SaveChangeAsync(cancellationToken);
            return new CreateEmployeeIdentityResponse()
            {
                Id = updatedEmployee.Id,
                LastName = updatedEmployee.Identity.LastName,
                FirstName = updatedEmployee.Identity?.FirstName,
                BirthDate = updatedEmployee.Identity?.BirthDate,
                BirthPlace = updatedEmployee.Identity?.BirthPlace,
                Gender = updatedEmployee.Identity?.Gender,
                Nationality = updatedEmployee.Identity?.Nationality,
                CIN = updatedEmployee.Identity?.CIN,
            };
        }
    }
}