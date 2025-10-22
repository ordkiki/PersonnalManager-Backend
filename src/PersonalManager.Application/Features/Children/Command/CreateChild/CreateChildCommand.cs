using MediatR;
using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.CreateChild
{
    public class CreateChildCommand : IRequest<CreateChildResponse>
    {
        public Gender? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? CIN { get; set; }
        public string? Nationality { get; set; }
        public IFormFile? Avatar { get; set; }
        public bool? IsDependent { get; set; }

        public required Guid? EmployeeId { get; set; }
    }
}