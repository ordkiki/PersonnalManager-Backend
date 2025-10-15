using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Exceptions;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Query.GetOneJob
{
    public class GetOneJobQueryHandler(IRepositoryQuery<Job> _repo) : IRequestHandler<GetOneJobQuery, JobDto>
    {
        public async Task<JobDto> Handle(GetOneJobQuery request, CancellationToken cancellationToken)
        {
            Job job = await _repo.FindByIdAsync(request.Id) ?? throw new ApiException("no Job were found", 400, false);
            return new JobDto
            {
                Id = job.Id,
                JobTitle = job.JobTitle,
                JobCode = job.JobCode,
                DepartementId = job.DepartementId,
            };
        }
    }   
}