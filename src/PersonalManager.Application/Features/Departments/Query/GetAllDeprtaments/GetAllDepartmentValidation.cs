using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Query.GetAllDeprtaments
{
    public class GetAllDepartmentValidation : AbstractValidator<GetAllDepartmentQuery>
    {
        public GetAllDepartmentValidation()
        {
            RuleFor(x => x.Limit)
                .GreaterThanOrEqualTo(0).WithMessage("Limit must be greater than 0")
                .LessThanOrEqualTo(100).WithMessage("Limit must be less than or equal to 100")
                .When(x => x.Limit.HasValue);
            RuleFor(x => x.Page).NotEmpty();
        }
    }
}
