using PersonaManager.Domain.Entities;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Query.GetOneEmployees
{
    public class GetOneEmployeeResponse
    {
        public Guid? EmployeeId { get; set; }
        public string? Matricule { get; set; }
        public string? Status { get; set; }
        public Identity? Identity { get; set; }
        public CivilStatus? CivilStatus { get; set; }
        public Adress? Adress { get; set; }
        public string? Contact { get; set; }
        public List<EmployeeBanksResponse>? Banks { get; set; }
        public List<EmployeeContractsResponse>? Contracts { get; set; }
        public List<EmployeeEducationResponse>? Educations  { get; set; }
        public string ? JobTitle { get; set; }
        public string ? Civility { get; set; }
        public string? ManagerName { get; set; }
    }

    public class EmployeeBanksResponse
    {
        public Guid? Id { get; init; }
        public string? Rib { get; set; }
        public string? Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }
    }

    public class EmployeeContractsResponse
    {
        public Guid? Id { get; set; }
        public string? ContratReference { get; set; }
        public string? TypeContract { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public float? SalaryMensual { get; set; }
    }

    public class EmployeeEducationResponse
    {
        public Guid? Id { get; init; }
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateTime? GraduationYear { get; set; }
        public string? Establishment { get; set; }
    }
}
