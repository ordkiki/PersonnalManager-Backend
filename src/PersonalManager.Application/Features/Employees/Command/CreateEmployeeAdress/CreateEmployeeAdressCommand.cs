using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeAdress
{
    public class CreateEmployeeAdressCommand  : IRequest<CreateEmployeeAdressResponse>
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? District { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
    }
}
