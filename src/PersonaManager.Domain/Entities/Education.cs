using PersonaManager.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Entities
{
    public class Education : BaseEntity
    {
        public string? Graduation { get; set; }
        public string? FieldOfStudy { get; set; }
        public DateTime? GraduationYear { get; set; }
        
        [ForeignKey(nameof(Employee))]
        public Guid? EmployeeId { get; set; }
        [ForeignKey(nameof(Child))]
        public Guid? IdChild { get; set; }
        
        [JsonIgnore]
        public Employee? Employee { get; set; }    
        public virtual Child? Child { get; set; }
    }
}
