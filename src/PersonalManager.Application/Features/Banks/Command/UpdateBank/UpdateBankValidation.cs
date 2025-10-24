using FluentValidation;
using PersonaManager.Domain.Enums;
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
            RuleFor(x => x.Bic).MaximumLength(11)
                            .WithMessage("The BIC cannot exceed 11 characters..").WithErrorCode(ErrCode.INVALID_VALUE.ToString())
                            .Matches("^[A-Z0-9]+$").WithMessage("only Majuscule letter").WithErrorCode(ErrCode.INVALID_FORMAT.ToString());

            RuleFor(x => x.Iban)
                .MaximumLength(34).WithMessage("The Iban cannot exceed 34 characters.").WithErrorCode(ErrCode.INVALID_VALUE.ToString())
                .Matches("^[A-Z0-9]+$").WithMessage("L'IBAN doesn't much special character").WithErrorCode(ErrCode.INVALID_FORMAT.ToString());

            RuleFor(x => x.Rib)
                .Length(20, 23).WithMessage("Le RIB doit contenir entre 20 et 23 caractères.")
                .Matches("^[0-9A-Z]+$").WithMessage("Le RIB doit contenir uniquement des lettres majuscules et des chiffres.");
        }
    }
}
