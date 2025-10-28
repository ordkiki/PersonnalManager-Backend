using MediatR;
using PersonalManager.Application.Dtos;
using PersonalManager.Application.Mappers;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Command.UpdateContract
{
    public class UpdateContractCommandHandler(IRepositoryCommand<Contract> _repo1, IRepositoryQuery<Contract> _repo2, IUnitOfWork _unit) : IRequestHandler<UpdateContractCommand, ContractDto>
    {
        public async Task<ContractDto> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            Contract? contract = await _repo2.FindByIdAsync(request.Id, cancellationToken) ??
               throw new Exception($"we can't find this contract");

            contract.StartDate = (request.StartDate!= null)? request.StartDate : contract.StartDate;
            contract.EndDate = (request.EndDate != null) ? request.EndDate : contract.EndDate;
            contract.IsActive = request.IsActive ?? contract.IsActive;
            contract.EmployeeId = contract.EmployeeId;
            contract.UpdatedAt = DateTime.UtcNow;

            Contract updatedContract = await _repo1.UpdateAsync(request.Id, contract, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);
            return updatedContract.ToDto();
        }
    }
}
