using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Command.UpdateJob
{
    public class UpdateJobCommandHandler(IRepositoryQuery<Job> _repo2, IRepositoryCommand<Job> _repo1, IUnitOfWork _unit, ICodeGenerator _generator) : IRequestHandler<UpdateJobCommand, JobDto>
    {
        public async Task<JobDto> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            Job ? job = await _repo2.FindByIdAsync(request.Id) ?? throw new ApiException("No job was found",400, false);
            job = await _repo1.UpdateAsync(request.Id, new Job
            {
                JobTitle = request.JobTitle,
                DepartementId = request.DepartementId,
                JobCode = (request.JobTitle == null)? request.JobCode : await _generator.SetCode(request.JobTitle)
            }, cancellationToken);
            return new JobDto
            {
                Id = job.Id,
                JobTitle = job.JobTitle,
                DepartementId = job.DepartementId,
                JobCode = job.JobCode,
            };
        }
    }
}
