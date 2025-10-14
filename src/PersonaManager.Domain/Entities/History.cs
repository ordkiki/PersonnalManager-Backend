using PersonaManager.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Entities
{
    public sealed class History : BaseEntity
    {
        public required string Action { get; set; } // Create/update/Delete
        public required Guid EntityId { get; set; }
        public string? EntityType { get; set; }// Employee
        public string? InitialState { get; set; }
        public string? FinalState { get; set; }
        public DateTime? ActionDate { get; set; } = DateTime.UtcNow;
    }
}
