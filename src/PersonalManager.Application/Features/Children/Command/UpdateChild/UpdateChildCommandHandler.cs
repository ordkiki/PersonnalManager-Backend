using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.UpdateChild
{
    public class UpdateChildCommandHandler(IRepositoryCommand<Child> _repo, IRepositoryQuery<Child> _repo2, IUnitOfWork _unit, IFileService _fileService) : IRequestHandler<UpdateChildCommand, UpdateChildResponse>
    {
        public async Task<UpdateChildResponse> Handle(UpdateChildCommand request, CancellationToken cancellationToken)
        {
            Child child = await _repo2.FindByIdAsync(request.Id, cancellationToken) ?? throw new ArgumentNullException("No department was found");


            child.Identity = new Identity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                Gender = request.Gender,
                Nationality = request.Nationality,
                Avatar = await _fileService.UploadAsync(request.Avatar, Folder.CHILD.ToString())
            };
            child.IsDependent = request.IsDependent;
            Child updatedChild = await _repo.UpdateAsync(request.Id, child, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);

            return new UpdateChildResponse()
            {
                Id = updatedChild.Id,
                FirstName = updatedChild.Identity.FirstName,
                LastName = updatedChild.Identity.LastName,
                BirthDate = updatedChild.Identity.BirthDate,
                BirthPlace = updatedChild.Identity.BirthPlace,
                Gender = updatedChild.Identity.Gender,
                Nationality = updatedChild.Identity.Nationality,
                Avatar = child.Identity.Avatar,
            };
        }
    }
}
