using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Dtos
{
    public class ContractDto
    {
        public required Guid Id { get; set; }
        public string? ContratReference { get; set; }
        public required TypeContrat TypeContrat { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public float? SalaryMensual { get; set; }
        public required Guid EmployeeId { get; set; }
    }
}
