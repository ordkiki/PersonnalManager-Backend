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
    public class Job : BaseEntity
    {
        public string? JobCode { get; set; }
        public required string JobTitle { get; set; }
        
        [ForeignKey(nameof(Departments))]
        public Guid? DepartementId { get; set; }
        
        [JsonIgnore]
        public virtual Department? Departments { get; set; }
    }
}
