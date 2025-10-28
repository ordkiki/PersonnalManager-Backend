using MediatR;
using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Command.CreateContract
{
    public class CreateContractCommand : IRequest<ContractDto>
    {
        public string? ContratReference { get; set; }
        public required TypeContrat TypeContrat { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public float? SalaryMensual { get; set; }
        public required Guid EmployeeId { get; set; }
    }
}
