using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.UpdateBank
{
    public class UpdateBankCommandHandler(IRepositoryCommand<Bank> _repo1, IRepositoryQuery<Bank> _repo2, IUnitOfWork _unit) : IRequestHandler<UpdateBankCommand, UpdateBankResponse>
    {
        public async Task<UpdateBankResponse> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            Bank? bank = await _repo2.FindByIdAsync((Guid)request.Id!, null) ??
               throw new Exception($"we can't find this bank");

            bank.Rib = request.Rib ?? bank.Rib;
            bank.Iban = request.Iban ?? bank.Iban;
            bank.CountryCode = request.CountryCode ?? bank.CountryCode;
            bank.EmployeeId = bank.EmployeeId;
            bank.AccountLabel = request.AccountLabel ?? bank.AccountLabel;
            bank.UpdatedAt = DateTime.UtcNow;

            Bank updatedBanque = await _repo1.UpdateAsync(request.Id, bank, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);
            return new UpdateBankResponse()
            {
                Id = updatedBanque.Id,
                EmployeeId = updatedBanque.EmployeeId,
                Iban = updatedBanque.Iban,
                Rib = updatedBanque.Rib,
                AccountLabel = updatedBanque.AccountLabel,
                Bic = updatedBanque.Bic,
                CountryCode = updatedBanque.CountryCode
            };
        }
    }
}
