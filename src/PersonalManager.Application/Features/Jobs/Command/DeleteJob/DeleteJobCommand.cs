using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Jobs.Command.DeleteJob
{
    public class DeleteJobCommand : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }
}
