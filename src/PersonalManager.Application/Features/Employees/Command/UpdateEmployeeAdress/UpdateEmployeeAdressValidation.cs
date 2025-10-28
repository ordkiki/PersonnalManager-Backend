using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeAdress
{
    public class UpdateEmployeeAdressValidation : AbstractValidator<UpdateEmployeeAdressCommand>
    {
        public UpdateEmployeeAdressValidation()
        {
            
        }
    }
}
