using FluentValidation;
using Microsoft.Extensions.Configuration;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.CreateChild
{
    public class CreateChildValidation : AbstractValidator<CreateChildCommand>
    {
        private readonly IConfiguration configuration; 
        public CreateChildValidation()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().WithErrorCode(ErrCode.EMPTY_VALUE.ToString()).WithMessage("parent id must not be empty");
            RuleFor(x => x.FirstName).NotEmpty().WithErrorCode(ErrCode.EMPTY_VALUE.ToString()).WithMessage("First name is required");
        }
    }
}
