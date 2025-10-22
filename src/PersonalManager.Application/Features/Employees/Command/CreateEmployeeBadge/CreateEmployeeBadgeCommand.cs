using MediatR;
using Microsoft.AspNetCore.Http;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeBadge
{
    public class CreateEmployeeBadgeCommand : IRequest<CreateEmployeeBadgeResponse>
    {
        public string? LastName { get; set; }
        public string? Matricule { get; init; }
        public required string FirstName { get; set; }
        public Gender? Gender { get; init; }
        public Civility? Civility { get; set; }
        public required string[] Email { get; set; }
        public required string[] PhoneNumber { get; set; }
        public IFormFile? Avatar { get; set; }
        public Guid? JobId { get; set; }
    }
}
