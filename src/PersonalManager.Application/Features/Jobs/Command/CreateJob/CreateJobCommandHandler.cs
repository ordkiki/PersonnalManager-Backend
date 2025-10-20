using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Command.CreateJob
{
    public class CreateJobCommandHandler(IRepositoryCommand<Job> _repo, ICodeGenerator _generator, IUnitOfWork _unit) : IRequestHandler<CreateJobCommand, JobDto>
    {
        public async Task<JobDto> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            Job job = new()
            {
                JobTitle = request.JobTitle,
                JobCode = await _generator.SetCode(request.JobTitle),
                DepartementId = request.DepartementId,
            };
            var result = await _repo.CreateAsync(job, cancellationToken).ContinueWith(t => new JobDto
            {
                Id = job.Id,
                JobTitle = t.Result.JobTitle,
                DepartementId = t.Result.DepartementId,
                JobCode = t.Result.JobCode,
            });
            await _unit.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
