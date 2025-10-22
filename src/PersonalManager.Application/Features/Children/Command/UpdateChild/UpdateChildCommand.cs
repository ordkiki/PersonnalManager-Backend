using MediatR;
using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Command.UpdateChild
{
    public class UpdateChildCommand : IRequest<UpdateChildResponse>
    {
        public required Guid Id {  get; set; }
        public Gender? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Nationality { get; set; }
        public IFormFile? Avatar { get; set; }
        public bool? IsDependent { get; set; }
    }
}