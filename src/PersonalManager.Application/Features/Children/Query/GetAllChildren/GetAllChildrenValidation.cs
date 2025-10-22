using FluentValidation;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Query.GetAllChildren
{
    public class GetAllChildrenValidation : AbstractValidator<GetAllChildrenQuery>
    {
        public GetAllChildrenValidation()
        {
            RuleFor(x => x.Limit).GreaterThan(-1).WithErrorCode(ErrCode.NEGATIVE_VALUE.ToString());
            RuleFor(x => x.Limit).GreaterThanOrEqualTo(1).WithErrorCode(ErrCode.NEGATIVE_VALUE.ToString());
        }
    }
}