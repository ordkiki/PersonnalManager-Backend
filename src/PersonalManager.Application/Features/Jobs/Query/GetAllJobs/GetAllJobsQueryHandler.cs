using MediatR;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Query.GetAllJobs
{
    public class GetAllJobsQueryHandler(IRepositoryQuery<Job> _repo) : IRequestHandler<GetAllJobsQuery, GetAllJobsQueryResponse>
    {
        public async Task<GetAllJobsQueryResponse> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Job, bool>> filter = Job => true;

            if (!string.IsNullOrWhiteSpace(request.Search))
                filter = dep =>
              (
                  string.IsNullOrEmpty(request.Search) ||
                  (dep.JobCode!.ToLower().Contains(request.Search.ToLower()) ||
                   dep.JobTitle!.ToLower().Contains(request.Search.ToLower()))
              )
              ;

            var (Job, total, allPage) = await _repo.FindManyAsync(
                filterExpression: filter,
                includes: null,
                limit: request.Limit,
                page: request.Page ?? 1,
                orderBy: q => q.OrderByDescending(date => date.CreatedAt));
                
            return new GetAllJobsQueryResponse
            {
                Data = [.. Job.Select(j => new Dtos.JobDto
                {
                    Id = j.Id,
                    JobTitle = j.JobTitle,
                    JobCode = j.JobCode,
                    DepartementId = j.DepartementId,
                })],
                Total = total,
                TotalPage = allPage,
            };
        }
    }
}
