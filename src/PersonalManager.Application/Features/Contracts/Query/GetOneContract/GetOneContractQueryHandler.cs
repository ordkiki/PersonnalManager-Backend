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

namespace PersonalManager.Application.Features.Contracts.Query.GetOneContract
{
    public class GetOneContractQueryHandler(IRepositoryQuery<Contract> _repo) : IRequestHandler<GetOneContractQuery, ContractDto>
    {
        public async Task<ContractDto> Handle(GetOneContractQuery request, CancellationToken cancellationToken)
        {
            Contract contract = await _repo.FindByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentNullException($"contract not found.");

            return contract.ToDto();
        }
    }
}
