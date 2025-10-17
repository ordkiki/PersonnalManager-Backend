using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeAdress
{
    public class CreateEmployeeAdressCommandHandler(IRepositoryQuery<Employee> _repo2, IRepositoryCommand<Employee> _repo1,IUnitOfWork _unit) : IRequestHandler<CreateEmployeeAdressCommand, CreateEmployeeAdressResponse>
    {
        public async Task<CreateEmployeeAdressResponse> Handle(CreateEmployeeAdressCommand request, CancellationToken cancellationToken)
        {

            Employee? employee = await _repo2.FindByIdAsync(request.Id) ?? throw new ApiException("no employee was found", 400, false);


            employee.Adress = new()
            {
                City = request.City,
                Area = request.Area,
                Street = request.Street,
                PostalCode = request.PostalCode,
                District = request.District,
                Region = request.Region,
                Country = request.Country
            };
        
            Employee updatedEmployee = await _repo1.UpdateAsync(request.Id, employee, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);
            return new CreateEmployeeAdressResponse()
            {
                Id = updatedEmployee.Id,
                Adress = updatedEmployee.Adress
            };
        }
    }
}