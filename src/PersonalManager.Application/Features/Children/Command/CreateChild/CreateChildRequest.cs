using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.CreateChild
{
    public class CreateChildRequest
    {
        public Gender? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Nationality { get; set; }
        public IFormFile? Avatar { get; set; }
        public bool? IsDependent { get; set; }

        public required Guid? EmployeeId { get; set; }
    }
    public record IdentityRequest
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Nationality { get; set; }
        public string? CIN { get; set; }
        public IFormFile? Avatar { get; set; }
    }

    public record EducationRequest
    {
        public string? Graduation { get; set; }
        public string? Etablissement { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateTime? GraduationYear { get; set; }
    }
}
