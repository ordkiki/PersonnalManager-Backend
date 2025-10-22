using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.UpdateChild
{
    public class UpdateChildResponse
    {
        public required Guid Id { get; set; }
        public Gender? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Nationality { get; set; }
        public Resource? Avatar { get; set; }
        public bool? IsDependent { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
