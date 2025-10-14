using MediatR;
using PersonalManager.Application.Features.Banks.Command.CreateBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.UpdateBank
{
    public class UpdateBankCommand : IRequest<UpdateBankResponse>
    {
        public Guid? Id { get; init; }
        public string? Rib { get; set; }
        public string? Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }
    }
}
