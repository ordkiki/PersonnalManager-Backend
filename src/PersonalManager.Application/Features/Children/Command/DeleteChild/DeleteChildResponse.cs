using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.DeleteChild
{
    public class DeleteChildResponse
    {
        public string? Id { get; init; }
        public Identity? Identity { get; set; }
        public bool? IsDependent { get; set; }
        public List<Education>? Educations { get; set; }
    }
}