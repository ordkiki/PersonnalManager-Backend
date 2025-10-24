using MediatR;
using PersonalManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.CreateBank
{
    public class CreateBankCommand : IRequest<BankDto>
    {
        public string? Rib { get; set; }
        public string? Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }
        public required Guid EmployeeId { get; init; }
    }
}
