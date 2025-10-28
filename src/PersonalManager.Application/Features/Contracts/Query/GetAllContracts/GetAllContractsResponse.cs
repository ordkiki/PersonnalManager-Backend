using PersonalManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Query.GetAllContracts
{
    public class GetAllContractsResponse
    {
        public IEnumerable<ContractDto>? Data { get; init; }
        public required long Total { get; init; } = default!;
        public required int TotalPage { get; init; } = default!;
    }
}
