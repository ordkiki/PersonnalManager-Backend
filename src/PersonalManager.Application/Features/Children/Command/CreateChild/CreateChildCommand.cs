using MediatR;
using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Entities;
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
        public Identity? Identity { get; set; }
        public IFormFile? Avatar { get; set; }
        public IEnumerable<Education>? Educations { get; set; }
        public bool? IsDependent { get; set; }
        public required Guid? EmployeeId { get; set; }
    }
}