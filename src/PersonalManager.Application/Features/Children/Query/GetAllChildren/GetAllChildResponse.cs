using PersonalManager.Application.Features.Children.Command.CreateChildEducation;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Query.GetAllChildren
{
    public class GetAllChildResponse
    {
        public IEnumerable<ChildrenResponse>? Data { get; set; }
        public long? Total { get; set; }
        public int? TotalPage { get; set; }
    }

    public class ChildrenResponse
    {
        public Guid? Id { get; init; }
        public Guid? EmployeeId { get; set; }
        public Gender? Gender { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public bool? IsDependent { get; set; }
        public string? Nationality { get; set; }
        public Resource? Profil { get; set; }
        public string? ParentName { get; set; }
        public List<ChildEdcation>? Educations { get; set; }
    }
}