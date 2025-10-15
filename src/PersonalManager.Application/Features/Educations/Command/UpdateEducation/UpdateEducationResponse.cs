using PersonalManager.Application.Features.Employees.Command.CreateEmployeeEducation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Educations.Command.UpdateEmployeeEducation
{
    
    public record UpdateEducation
    {
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Establishment { get; set; }
        public DateTime? GraduationYear { get; set; }
    }
    public class UpdateEducationResponse
    {
        public Guid? Id { get; set; }
        public UpdateEducation? Education { get; set; }
    }
}