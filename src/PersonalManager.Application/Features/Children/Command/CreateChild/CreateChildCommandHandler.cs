using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.CreateChild
{
    public class CreateChildCommandHandler(IRepositoryCommand<Child> _repo, IFileService _file, IUnitOfWork _unit) : IRequestHandler<CreateChildCommand, CreateChildResponse>
    {
        public async Task<CreateChildResponse> Handle(CreateChildCommand request, CancellationToken cancellationToken)
        {
            Child Child = new()
            {
                Identity = new()
                {
                    LastName = request?.LastName,
                    FirstName = request!.FirstName!,
                    BirthDate = request?.BirthDate,
                    BirthPlace = request?.BirthPlace,
                    CIN = request?.CIN,
                    Nationality = request?.Nationality,
                    Avatar = request!.Avatar! != null ? await _file.UploadAsync(request.Avatar, Folder.CHILDREN.ToString()) : null,
                },
                
                IsDependent = request.IsDependent,
                EmployeeId = request.EmployeeId
            };

            await _repo.CreateAsync(Child, cancellationToken);
            await _unit.SaveChangesAsync(cancellationToken);

            return new CreateChildResponse
            {
                Identity = Child.Identity,
                IsDependent = Child.IsDependent
            };
        }
    }
}