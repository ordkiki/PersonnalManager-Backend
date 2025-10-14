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
    public class Bank : BaseEntity
    {
        public required string Rib { get; set; }
        public required string Iban { get; set; }
        public string? CountryCode { get; set; }
        public string? Bic { get; set; }
        public string? AccountLabel { get; set; }

        [ForeignKey(nameof(Employee))]
        public required Guid EmployeeId { get; set; }

        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}
