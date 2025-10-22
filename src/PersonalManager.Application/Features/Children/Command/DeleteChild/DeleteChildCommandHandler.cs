using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.DeleteChild
{
    public class DeleteChildCommandHandler(IRepositoryCommand<Child> _repo, IRepositoryCommand<Child> _repo1, IUnitOfWork _unit) : IRequestHandler<DeleteChildCommand, bool>
    {
        public async Task<bool> Handle(DeleteChildCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}