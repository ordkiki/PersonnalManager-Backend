using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.CreateBank
{
    public class CreateBankCommandHandler(IRepositoryCommand<Bank> _repo, IUnitOfWork _unit) : IRequestHandler<CreateBankCommand, CreateBankResponse>
    {
        public async Task<CreateBankResponse> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            Bank bank = new ()
            {
                Rib = request.Rib!,
                Iban = request.Iban!,
                CountryCode = request.CountryCode,
                Bic = request.Bic,
                AccountLabel = request.AccountLabel,
                EmployeeId = request.EmployeeId!.Value
            };

            await _repo.CreateAsync(bank, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);
            return new CreateBankResponse()
            {
                Id = bank.Id,
                EmployeeId = bank.EmployeeId,
                Iban = bank.Iban,
                Rib = bank.Rib,
                AccountLabel = bank.AccountLabel,
                Bic = bank.Bic,
                CountryCode = bank.CountryCode
            };
        }
    }
}
