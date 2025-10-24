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

namespace PersonalManager.Application.Features.Employees.Query.GetAllEmployees
{
    public class GetAllEmployeeQueryResponse
    {
        public IEnumerable<EmployeeInformationResponse>? Data { get; set; }
        public long? Total { get; set; }
        public int? TotalPage { get; set; }
    }

    public class EmployeeInformationResponse
    {
        public Guid? Id { get; set; }
        public string? Matricule { get; set; }
        public Identity? Identity { get; set; }
        public CivilStatus? CivilStatus { get; set; }
        public Adress? Adress { get; set; }
        public Contact? Contact { get; set; }
        public EmployeeStatus? Status { get; set; }
        public Civility? Civility { get; set; }
        public string? JobTitle { get; set; }
        public string? ManagerName { get; set; }
        public string? Manager { get; set; }
        public Job? Job { get; set; }
        public List<EmployeeChild>? Children { get; set; }
        public List<EmployeeEducation>? Educations { get; set; }
        public List<EmployeeContract>? Contracts { get; set; }
        public List<EmployeeBank>? Banks { get; set; }
    }

    public class EmployeeChild
    {
        public Guid Id { get; set; }
        public Identity? Identity { get; set; } 
        public bool? IsDependent { get; set; }
    }

    public class EmployeeBank
    {
        public Guid Id { get; set; }
        public required string Rib { get; set; }
        public required string Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }
    }

    public class EmployeeContract
    {
        public Guid Id { get; set; }
        public string? ContratReference { get; set; }
        public TypeContrat? TypeContrat { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public float? SalaryMensual { get; set; }
    }

    public class EmployeeEducation
    {
        public Guid Id { get; set; }
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateTime? GraduationYear { get; set; }
        public string? Establishment { get; set; }
    }
}