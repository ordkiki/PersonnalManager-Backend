using MediatR;
using PersonalManager.Application.Features.Educations.Command.UpdateEmployeeEducation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Educations.Command.UpdateEducation
{
    public class UpdateEducationCommand : IRequest<UpdateEducationResponse>
    {
        public Guid? Id { get; set; }
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Establishment { get; set; }
        public DateTime? GraduationYear { get; set; }
    }
}
