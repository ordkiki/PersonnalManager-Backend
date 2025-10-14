using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.DeleteBank
{
    public class DeleteBankCommand : IRequest<DeleteBankResponse>
    {
        public required Guid Id { get; init; }
    }
}