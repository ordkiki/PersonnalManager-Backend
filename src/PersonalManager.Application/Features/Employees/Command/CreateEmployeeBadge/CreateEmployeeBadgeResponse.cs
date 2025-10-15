using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Command.CreateEmployeeBadge
{
    public class CreateEmployeeBadgeResponse
    {
        public Guid? Id { get; set; }
        public string? LastName { get; set; }
        public string? Matricule { get; init; }
        public string? Gender { get; init; }
        public string? FirstName { get; set; }
        public Civility? Civility { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? PosteName { get; set; }
        public string? DepartmentName { get; set; }
    }
}
