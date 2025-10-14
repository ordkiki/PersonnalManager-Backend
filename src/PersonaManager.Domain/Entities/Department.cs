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
    public class Department : BaseEntity
    {
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        
        [ForeignKey(nameof(ParentDepartment))]
        public Guid? ParentDepartmentId { get; set; }
        
        [JsonIgnore]
        public virtual Department? ParentDepartment { get; set; }
        public virtual List<Department>? DepartmentsFils { get; set; }
    }
}
