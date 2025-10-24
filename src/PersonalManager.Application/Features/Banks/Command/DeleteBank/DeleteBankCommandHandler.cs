using MediatR;
using PersonalManager.Application.Dtos;
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
    public class DeleteBankCommandHandler(IRepositoryCommand<Bank> _repo, IRepositoryQuery<Bank> _repo2, IUnitOfWork _unit) : IRequestHandler<DeleteBankCommand, bool>
    {
        public async Task<bool> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.DeleteAsync(request.Id, cancellationToken);
                await _unit.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException("No bank found", 400, false);
            }
        }
    }
}
