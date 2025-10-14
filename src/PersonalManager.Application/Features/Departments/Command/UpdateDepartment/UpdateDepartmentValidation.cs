using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.UpdateDepartment
{
    public class UpdateDepartmentValidation : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentValidation()
        {
            RuleFor(x => x.DepartmentName).MaximumLength(500);
        }
    }
}
