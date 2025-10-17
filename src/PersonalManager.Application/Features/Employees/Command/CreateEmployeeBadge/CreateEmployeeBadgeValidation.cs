using FluentValidation;
using PersonaManager.Domain.Commons.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeBadge
{
    public class CreateEmployeeBadgeValidation : AbstractValidator<CreateEmployeeBadgeCommand>
    {
        public CreateEmployeeBadgeValidation()
        {
            RuleFor(employee => employee.FirstName).NotEmpty().WithMessage("Employee FirstName is required").WithErrorCode(ErrCode.EMPTY_VALUE.ToString());
            RuleFor(employee => employee.LastName).NotEmpty().WithMessage("Employee FirstName is required").WithErrorCode(ErrCode.EMPTY_VALUE.ToString());
            When(employee => employee.Avatar == null, () => RuleFor(employee => employee.Avatar).Null());
            When(employee => employee.JobId == null, () => RuleFor(employee => employee.JobId).Null());

            RuleFor(x => x.Civility)
               .NotEmpty().WithMessage("Civility is required").WithErrorCode(ErrCode.EMPTY_VALUE.ToString())
               .IsInEnum().WithMessage("Civility must be in enum(eg: MME, MR, MLLE").WithErrorCode(ErrCode.NOT_IN_ENUM.ToString());

            RuleFor(x => x.Gender)
               .NotEmpty().WithMessage("Gender is required")
               .IsInEnum().WithMessage("gender must be in enum(eg: MALE, FEMALE").WithErrorCode(ErrCode.NOT_IN_ENUM.ToString());

            RuleForEach(x => x.Email)
                .NotEmpty().WithMessage("EmailAdress is required").WithErrorCode(ErrCode.EMPTY_VALUE.ToString())
                .Matches(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" +
                     @"([-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w])+(?:\.[-a-zA-Z0-9!#\$%&'\*\+/=\?\^_`\{\}\|~\w]+)*)" +
                     @"@((\[(\d{1,3}\.){3}\d{1,3}\])|(([a-zA-Z0-9\-]+\.)+[a-zA-Z]{2,}))$")
                .WithMessage("Email Format does not valid");
            RuleForEach(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number must be required is required").WithErrorCode(ErrCode.EMPTY_VALUE.ToString())
                .MinimumLength(8).WithMessage("Phone must  more than 8 number")
                .MaximumLength(14).WithMessage("Phone number length does not exceed to 13 numbers")
                .Matches("^\\+?[0-9]+$").WithMessage("Only numeric");
        }
    }
}
