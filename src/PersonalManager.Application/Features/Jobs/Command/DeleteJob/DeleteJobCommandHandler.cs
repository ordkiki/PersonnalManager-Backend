using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Command.DeleteJob
{
    public class DeleteJobCommandHandler(IRepositoryCommand<Job> _repo, IRepositoryQuery<Job> _repo2, IUnitOfWork _unit) : IRequestHandler<DeleteJobCommand, bool>
    {
        public async Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            Job x = await _repo2.FindByIdAsync(request.Id) ?? throw new ApiException("No Job was found",400, false);
            if (await _repo.DeleteAsync(request.Id, cancellationToken))
            {
                await _unit.SaveChangeAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}