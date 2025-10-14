using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Query.GetBankBy
{
    public class GetBankByQuery : IRequest<GetBankByResponse>
    {
        public required Guid? Id { get; init; }
        public string? Iban { get; init; }
        public string? Bic { get; init; }
        public string? CountryCode { get; init; }
    }
}