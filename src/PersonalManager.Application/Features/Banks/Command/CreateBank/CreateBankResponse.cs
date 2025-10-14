using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.CreateBank
{
    public class CreateBankResponse
    {
        public required Guid Id { get; init; }
        public required string Rib { get; set; }
        public required string Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }
        public required Guid EmployeeId { get; init; }
    }
}