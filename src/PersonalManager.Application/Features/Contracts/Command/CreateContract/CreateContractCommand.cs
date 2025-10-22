using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Command.CreateContract
{
    public class CreateContractCommand
    {
        public string? ContratReference { get; set; }
        public TypeContrat? TypeContrat { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public float? SalaryMensual { get; set; }
    }
}
