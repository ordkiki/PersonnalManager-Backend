using PersonaManager.Domain.Commons;
using PersonaManager.Domain.Enums;
using PersonaManager.Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string? Matricule { get; set; }
        public Identity? Identity { get; set; }
        public CivilStatus? CivilStatus { get; set; }
        public Adress? Adress { get; set; }
        public Contact? Contact { get; set; }
        public EmployeeStatus? Status { get; set; }

        [ForeignKey(nameof(Job))]
        public Guid? PostId { get; set; }
        [ForeignKey(nameof(Manager))]
        public Guid? ManagerId { get; set; }

        public virtual Job? Job { get; set; }
        public virtual Employee? Manager { get; set; }
        public virtual List<Child>? Children { get; set; }
        public virtual List<Education>? Educations { get; set; }
        public virtual List<Contract>? Contracts { get; set; }
        public virtual List<Bank>? Banks { get; set; }
    }
}
