using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeAdress
{
    public class CreateEmployeeAdressResponse
    {
        public Guid? Id { get; set; }
        public Adress? Adress { get; set; }
    }
}