using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace PersonalManager.Application.Features.Banks.Query.GetBankBy
{
    public class GetBankByQueryHandler(IRepositoryQuery<Bank> _repo)
        : IRequestHandler<GetBankByQuery, GetBankByResponse>
    {
        public async Task<GetBankByResponse> Handle(GetBankByQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Bank, bool>> filter = b => b.Iban == request.Iban;

            
            List<Expression<Func<Bank, object>>> includes =
            [
                b => b.Employee!
            ];

            Bank bank = await _repo.GetByAsync(filter, null, includes) ?? throw new KeyNotFoundException($"Bank with IBAN {request.Iban} not found.");

            return new GetBankByResponse
            {
                AccountLabel = bank.AccountLabel,
                Bic = bank.Bic,
                CountryCode = bank.CountryCode,
                Iban = bank.Iban,
                Id = bank.Id,
                Rib = bank.Rib,
                EmployeeId = bank.EmployeeId
            };
        }
    }
}