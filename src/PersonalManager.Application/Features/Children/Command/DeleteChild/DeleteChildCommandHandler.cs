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
    public class DeleteChildCommandHandler(IRepositoryCommand<Child> _repo, IRepositoryCommand<Child> _repo1, IUnitOfWork _unit) : IRequestHandler<DeleteChildCommand, DeleteChildResponse>
    {
        public async Task<DeleteChildResponse> Handle(DeleteChildCommand request, CancellationToken cancellationToken)
        {
            throw new Exception("Not Implemented");
            //Child? child = await _repo1.Find8/(request.Id, cancellationToken);
            //await _repo.DeleteAsync(request.Id, cancellationToken);
            //await _unit.SaveChangeAsync(cancellationToken);
            //return new DeleteChildResponse()
            //{
            //    Identity = child?.Identity,
            //    Educations = child?.Educations.ToList(),
            //    IsDependent = child?.IsDependent
            //};
        }
    }
}