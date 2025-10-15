using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Educations.Command.DeleteEducation
{
    public class DeleteEducationCommandHandler(IRepositoryCommand<Education> _repo) : IRequestHandler<DeleteEducationCommand, bool>
    {
        public async Task<bool> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id, cancellationToken);
        }
    }
}