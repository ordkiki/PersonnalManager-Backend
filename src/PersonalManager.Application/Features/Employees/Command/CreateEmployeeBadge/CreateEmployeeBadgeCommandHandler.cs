using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeBadge
{
    public class CreateEmployeeBadgeCommandHandler(IRepositoryCommand<Employee> _repo, IEmployeeService _repo2, IRepositoryQuery<Job> _Jobrepo,  IFileService _file, ICodeGenerator _generator, IUnitOfWork _unit) : IRequestHandler<CreateEmployeeBadgeCommand, CreateEmployeeBadgeResponse>
    {
        public async Task<CreateEmployeeBadgeResponse> Handle(CreateEmployeeBadgeCommand request, CancellationToken cancellationToken)
        {

            if (request?.Email is not null)
            {
                foreach (string email in request.Email)
                {
                    Employee? existingEmployee = await _repo2.GetByEmailAsync(request.Email);
                    if (existingEmployee != null)
                        throw new ApiException("email is already used by another employee", 400, false);
                }
            }
            Job j = new () { JobTitle = ""};
            if (request.JobId is not null)
            {
                j = await _Jobrepo.FindByIdAsync((Guid)request.JobId) ??
                   throw new ApiException("no poste found", 400, false);
            }
            else request.JobId = null;

                Employee e = new()
                {
                    Matricule = await _generator.GenerateMatricule("", ""),
                    Identity = new()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Avatar = await _file.UploadAsync(request.Avatar, "employee"),
                        Gender = request.Gender,
                    },
                    Civility = request.Civility,
                    Contact = new()
                    {
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber
                    },

                    JobId = request.JobId,
                    Status = EmployeeStatus.ACTIVE,

                };


            await _repo.CreateAsync(e, cancellationToken);
            await _unit.SaveChangeAsync(cancellationToken);

            return new CreateEmployeeBadgeResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Matricule = request.Matricule,
                Civility = request.Civility,
                Gender = request.Gender.ToString(),
                PosteName = j.JobTitle,
            };
        }
    }
}
