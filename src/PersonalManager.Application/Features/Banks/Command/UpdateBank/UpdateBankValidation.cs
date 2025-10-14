using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.UpdateBank
{
    public class UpdateBankValidation : AbstractValidator<UpdateBankCommand>
    {
        public UpdateBankValidation()
        {
            RuleFor(x => x.Bic)
               .Length(11).WithMessage("The BIC cannot exceed 11 characters..")
               .Matches("^[A-Z0-9]+$").WithMessage("Le BIC ne peut contenir que des lettres majuscules et des chiffres.");

            RuleFor(x => x.Iban)
                .NotEmpty().WithMessage("Iban doesn't empty")
                .Length(34).WithMessage("The Iban cannot exceed 34 characters.")
                .Matches("^[A-Z0-9]+$").WithMessage("L'IBAN doesn't much special character");

            RuleFor(x => x.Rib)
                .NotEmpty().WithMessage("Rib doesn't empty.")
                .Length(23).WithMessage("The Rib cannot exceed 23 characters.")
                .Matches("^[0-9]{5}[0-9]{5}[0-9A-Z]{11}[0-9]{2}$").WithMessage("The RIB must contain only digits and valid letters in the correct format (bank code, branch code, account number, key");

            RuleFor(x => x.CountryCode)
                .MaximumLength(10).WithMessage("the country code can not exceed at 10 character");
            RuleFor(x => x.AccountLabel)
                .MaximumLength(500).WithMessage("account label cannot exceed 500 octet.");
        }
    }
}
