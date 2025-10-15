using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Query.GetAllJobs
{
    public class GetAllJobsQueryResponse
    {
        public IEnumerable<JobDto> Data { get; set; } = Enumerable.Empty<JobDto>();
        public long Total { get; set; }
        public int TotalPage { get; set; }  
    }
}