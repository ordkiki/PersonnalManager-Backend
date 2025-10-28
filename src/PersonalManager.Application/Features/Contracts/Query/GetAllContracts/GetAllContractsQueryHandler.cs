using MediatR;
using PersonalManager.Application.Dtos;
using PersonalManager.Application.Features.Banks.Query.GetAllBanks;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Query.GetAllContracts
{
    public class GetAllContractsQueryHandler(IRepositoryQuery<Contract> _repo) : IRequestHandler<GetAllContractsQuery, GetAllContractsResponse>
    {
        public async Task<GetAllContractsResponse> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Contract, bool>> filter = b => true;

            if (!string.IsNullOrEmpty(request.Search))
            {
                filter = contract =>
                  (contract.EmployeeId != Guid.Empty && contract.EmployeeId!.ToString()!.Contains(request.Search, StringComparison.CurrentCultureIgnoreCase));
            }


            (IEnumerable<Contract> contracts, long total, int allPage) = await _repo.FindManyAsync(
               filterExpression: filter,
               includes: null,
               limit: request.Limit ?? 10,
               page: request.Page ?? 1,
               orderBy: q => q.OrderByDescending(date => date.CreatedAt)
           );

            return new GetAllContractsResponse()
            {
                Data = contracts.Select(contract => new ContractDto
                {
                    Id = contract.Id,
                    SalaryMensual = contract.SalaryMensual,
                    IsActive = contract.IsActive,
                    StartDate = contract.StartDate,
                    EndDate = contract.EndDate,
                    TypeContrat = contract.TypeContrat,
                    EmployeeId = contract.EmployeeId,
                }).ToList(),
                Total = total,
                TotalPage = allPage,
            };
        }
    }
}
