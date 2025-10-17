using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeIdentity
{
    public class CreateEmployeeIdentityCommand : IRequest<CreateEmployeeIdentityResponse>
    {
        public Guid? EmployeeId { get; set; }
        public Gender? Gender { get; set; }
        public string? LastName { get; set; }
        public string? CIN { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Nationality { get; set; }
        public IFormFile? Image { get; set; }
    }
}