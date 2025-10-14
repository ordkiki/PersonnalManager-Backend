using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using PersonaManager.Domain.ValuesObject;
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
                    LastName = request.Identity?.LastName,
                    FirstName = request.Identity.FirstName,
                    BirthDate = request.Identity.BirthDate,
                    BirthPlace = request.Identity.BirthPlace,
                    CIN = request.Identity.CIN,
                    Nationality = request.Identity.Nationality,
                    Avatar = request.Avatar != null ? await _file.UploadAsync(request.Avatar, "child") : null,
                },
                
                IsDependent = request.IsDependent,
                EmployeeId = request.EmployeeId
            };

            await _repo.CreateAsync(Child, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);

            return new CreateChildResponse
            {
                Identity = Child.Identity,
                Educations = Child.Educations,
                IsDependent = Child.IsDependent
            };
        }
    }
}