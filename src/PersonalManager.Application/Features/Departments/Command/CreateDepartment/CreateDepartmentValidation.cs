using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Departments.Command.CreateDepartment
{
    public class CreateDepartmentValidation : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentValidation()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithErrorCode("EMPTY");
        }
    }
}
