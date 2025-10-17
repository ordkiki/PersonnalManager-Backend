using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.CreateChild
{
    public record CreateChildResponse
    {
        public Identity? Identity { get; set; }
        public IEnumerable<Education>? Educations { get; set; }
        public bool? IsDependent { get; set; }
    }
}