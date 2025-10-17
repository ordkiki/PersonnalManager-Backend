using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Command.CreateJob
{
    public record CreateJobRequest
    {
        public required string JobTitle { get; set; }
        public Guid? DepartementId { get; set; }
    }
}
