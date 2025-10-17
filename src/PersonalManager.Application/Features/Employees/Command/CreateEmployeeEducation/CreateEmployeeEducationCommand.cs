using MediatR;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeEducation
{
    public class CreateEmployeeEducationCommand : IRequest<CreateEmployeeEducationResponse>
    {
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Establishment { get; set; }
        public DateTime? GraduationYear { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
