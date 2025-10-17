using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.DeleteChild
{
    public class DeleteChildCommand : IRequest<DeleteChildResponse>
    {
        public required Guid Id { get; set; }
    }
    
}
