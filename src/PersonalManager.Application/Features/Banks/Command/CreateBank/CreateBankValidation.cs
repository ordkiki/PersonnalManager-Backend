using FluentValidation;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Command.CreateBank
{
    public class CreateBankValidation : AbstractValidator<CreateBankCommand>
    {
        public CreateBankValidation()
        {
            RuleFor(x => x.Bic).MaximumLength(11)
                .WithMessage("The BIC cannot exceed 11 characters..").WithErrorCode(ErrCode.INVALID_VALUE.ToString())
                .Matches("^[A-Z0-9]+$").WithMessage("only Majuscule letter").WithErrorCode(ErrCode.INVALID_FORMAT.ToString());

            RuleFor(x => x.Iban)
                .NotEmpty().WithMessage("Iban doesn't empty").WithErrorCode(ErrCode.EMPTY_VALUE.ToString())
                .MaximumLength(34).WithMessage("The Iban cannot exceed 34 characters.").WithErrorCode(ErrCode.INVALID_VALUE.ToString())
                .Matches("^[A-Z0-9]+$").WithMessage("L'IBAN doesn't much special character").WithErrorCode(ErrCode.INVALID_FORMAT.ToString());

            RuleFor(x => x.Rib)
                .NotEmpty().WithMessage("Rib ne peut pas être vide.").WithErrorCode(ErrCode.EMPTY_VALUE.ToString())
                .Length(20, 23).WithMessage("Le RIB doit contenir entre 20 et 23 caractères.")
                .Matches("^[0-9A-Z]+$").WithMessage("Le RIB doit contenir uniquement des lettres majuscules et des chiffres.");

            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Employee id property Does not empty").WithErrorCode(ErrCode.EMPTY_VALUE.ToString());
        }
    }
}