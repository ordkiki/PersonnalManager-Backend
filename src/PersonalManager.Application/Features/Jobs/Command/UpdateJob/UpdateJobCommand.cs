using MediatR;
using PersonalManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Command.UpdateJob
{
    public class UpdateJobCommand : IRequest<JobDto>
    {
        public required Guid Id { get; set; }
        public string? JobCode { get; set; }
        public required string JobTitle { get; set; }
        public Guid? DepartementId { get; set; }
    }
}
