using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Command.CreateContract
{
    public class CreateContractCommandHandler(IRepositoryCommand<Contract> _repo, IRepositoryQuery<Contract> _repo2, IRepositoryQuery<Contract> _repo3, IUnitOfWork _unit) : IRequestHandler<CreateContractCommand, ContractDto>
    {
        public async Task<ContractDto> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            Contract contract = new Contract()
            {
                ContratReference = "REF-Contrat",
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TypeContrat = request.TypeContrat,
                EmployeeId = request.EmployeeId,
                SalaryMensual = request.SalaryMensual,
                IsActive = true,
            };

            await _repo.CreateAsync(contract, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);

            return new ContractDto
            {
                Id = contract.Id,
                TypeContrat = contract.TypeContrat,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                IsActive = contract.IsActive,
                ContratReference = contract?.ContratReference,
                SalaryMensual = contract?.SalaryMensual,
                EmployeeId = contract.EmployeeId
            };
        }
    }
}
