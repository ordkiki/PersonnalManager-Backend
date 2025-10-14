using PersonaManager.Domain.Commons;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Entities
{
    public class Child : BaseEntity
    {
        public Identity? Identity { get; set; }
        public IEnumerable<Education>? Educations { get; set; }
        public bool? IsDependent { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid? EmployeeId { get; set; }

        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}
