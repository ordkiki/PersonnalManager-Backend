using FluentValidation;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.UpdateChild
{
    public class UpdateChildValidation : AbstractValidator<UpdateChildCommand>
    {
        public UpdateChildValidation()
        {
            
            RuleFor(x => x.FirstName).MinimumLength(2).WithErrorCode(ErrCode.INDEX_OUT_OF_RANGE.ToString()).WithMessage("First name is required");
        }
    }
}
