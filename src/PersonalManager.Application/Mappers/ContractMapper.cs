using PersonalManager.Application.Dtos;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Mappers
{
    public static class ContractMapper
    {
        public static ContractDto ToDto(this Contract contract)
        {
            return new ContractDto()
            {
                Id = contract.Id,
                StartDate = contract.StartDate,
                TypeContrat = contract.TypeContrat,
                EndDate = contract.EndDate,
                IsActive = contract.IsActive,
                SalaryMensual = contract.SalaryMensual,
                ContratReference = contract.ContratReference,
                EmployeeId = contract.EmployeeId,
            };
        }
    }
}
