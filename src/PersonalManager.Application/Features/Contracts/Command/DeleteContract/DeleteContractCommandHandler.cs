using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Command.DeleteContract
{
    public class DeleteContractCommandHandler(IRepositoryCommand<Contract> _repo) : IRequestHandler<DeleteContractCommand, bool>
    {
        public async Task<bool> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.DeleteAsync(request.Id, cancellationToken);
                return true;
            }
            catch (ArgumentException ex)
            {
                throw new (ex.Message);
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
