using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeAdress
{
    public class UpdateEmployeeAdressCommandHandler(IRepositoryQuery<Employee> _repo2, IRepositoryCommand<Employee> _repo1,IUnitOfWork _unit) : IRequestHandler<UpdateEmployeeAdressCommand, UpdateEmployeeAdressResponse>
    {
        public async Task<UpdateEmployeeAdressResponse> Handle(UpdateEmployeeAdressCommand request, CancellationToken cancellationToken)
        {

            Employee? employee = await _repo2.FindByIdAsync(request.EmployeeId, cancellationToken) ?? throw new ApiException("no employee was found", 400, false);


            employee.Adress = new()
            {
                City = request.City ?? employee.Adress?.City,
                Area = request.Area ?? employee.Adress?.Area,
                Street = request.Street ?? employee.Adress?.Street,
                PostalCode = request.PostalCode ?? employee.Adress?.PostalCode,
                District = request.District ?? employee.Adress?.District,
                Region = request.Region ?? employee.Adress?.Region,
                Country = request.Country ?? employee.Adress?.Country
            };
        
            Employee updatedEmployee = await _repo1.UpdateAsync(request.EmployeeId, employee, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);
            return new UpdateEmployeeAdressResponse()
            {
                Id = updatedEmployee.Id,
                Adress = updatedEmployee.Adress,
                
            };
        }
    }
}