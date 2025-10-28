using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonalManager.Application.Mappers;
using PersonaManager.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace PersonalManager.Application.Features.Banks.Query.GetBankBy
{
    public class GetBankByIdQueryHandler(IRepositoryQuery<Bank> _repo)
        : IRequestHandler<GetBankByIdQuery, BankDto>
    {
        public async Task<BankDto> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {

            
            List<Expression<Func<Bank, object>>> includes =
            [
                b => b.Employee!
            ];

            Bank bank = await _repo.FindByIdAsync(request.Id, cancellationToken) ?? throw new KeyNotFoundException($"bank not found.");

            return bank.ToDto();
        }
    }
}