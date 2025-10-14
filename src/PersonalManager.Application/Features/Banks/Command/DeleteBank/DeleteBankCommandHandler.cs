using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.DeleteBank
{
    public class DeleteBankCommandHandler(IRepositoryCommand<Bank> _repo, IRepositoryQuery<Bank> _repo2, IUnitOfWork _unit) : IRequestHandler<DeleteBankCommand, DeleteBankResponse>
    {
        public async Task<DeleteBankResponse> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            Bank? bankDeleted = await _repo2.FindByIdAsync((Guid)request.Id) ??
                throw new ApiException("No bank found", 400, false);

            await _repo.DeleteAsync(request.Id, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);
            return new DeleteBankResponse()
            {
                Id = bankDeleted.Id,
                EmployeeId = bankDeleted.EmployeeId,
                Iban = bankDeleted.Iban,
                Rib = bankDeleted.Rib,
                AccountLabel = bankDeleted.AccountLabel,
                Bic = bankDeleted.Bic,
                CountryCode = bankDeleted.CountryCode
            };
        }
    }
}
