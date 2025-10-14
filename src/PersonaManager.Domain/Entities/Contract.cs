using PersonaManager.Domain.Commons;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Entities
{
    public class Contract : BaseEntity
    {
        public string? ContratReference { get; set; }
        public TypeContrat? TypeContrat { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public float? SalaryMensual { get; set; }
        
        [ForeignKey(nameof(Employee))]
        public Guid? EmployeeId { get; set; }    
        
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}
