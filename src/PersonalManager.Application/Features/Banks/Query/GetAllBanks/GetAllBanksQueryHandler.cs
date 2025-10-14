using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Query.GetAllBanks
{
    public class GetAllBanksQueryHandler(IRepositoryQuery<Bank> _repo) : IRequestHandler<GetAllBanksQuery, GetAllBanksResponse>
    {
        public async Task<GetAllBanksResponse> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Bank, bool>> filter = b => true;

            if (!string.IsNullOrEmpty(request.Search))
            {
                filter = bank =>
                  (bank.EmployeeId != null && bank.EmployeeId!.ToString()!.ToLower().Contains(request.Search)) ||
                  bank.AccountLabel != null && bank.AccountLabel!.ToLower().Contains(request.Search.ToLower()) ||
                  (bank.Bic != null && bank.Bic!.ToLower().Contains(request.Search.ToLower()));
            }

            (IEnumerable<Bank> banks, long total, int allPage) = await _repo.FindManyAsync(
               filterExpression: filter,
               includes: null,
               limit: request.Limit ?? 10,
               page: request.Page ?? 1,
               orderBy: q => q.OrderByDescending(date => date.CreatedAt)
           );

            return new GetAllBanksResponse()
            {
                Data = banks.Select(bank => new Bank
                {
                    Id = bank.Id,
                    EmployeeId = bank.EmployeeId,
                    Iban = bank.Iban,
                    Rib = bank.Rib,
                    AccountLabel = bank.AccountLabel,
                    Bic = bank.Bic,
                    CountryCode = bank.CountryCode
                }).ToList(),
                Total = total,
                TotalPage = allPage,
            };
        }
    }
}
