using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeEducation
{

    public record EmployeeEducation
    {
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Establishment { get; set; }
        public DateTime? GraduationYear { get; set; }
        public Guid? EmployeeId { get; set; }
    }
    public class CreateEmployeeEducationResponse
    {
        public Guid? Id { get; set; }
        public IEnumerable<EmployeeEducation>? Educations { get; set; }
    }
}