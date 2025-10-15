using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.CreateChildEducation
{
    public class CreateChildEducationCommand : IRequest<CreateChildEducationResponse>
    {
        public Guid? ChildId { get; set; }
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public string? Establishment { get; set; }
        public DateTime? GraduationYear { get; set; }
    }
}