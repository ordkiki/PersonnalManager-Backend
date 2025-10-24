using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Mappers
{
    public static class BankMapper
    {
        public static BankDto ToDto(this Bank bank)
        {
            return new BankDto()
            {
                Id = bank.Id,
                EmployeeId = bank.EmployeeId,
                Iban = bank.Iban,
                Rib = bank.Rib,
                AccountLabel = bank.AccountLabel,
                Bic = bank.Bic,
                CountryCode = bank.CountryCode
            };
        }
    }
}
