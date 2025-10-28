using MediatR;
using PersonalManager.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Contracts.Query.GetAllContracts
{
    public class GetAllContractsQuery : IRequest<GetAllContractsResponse>
    {
        public string? Search { get; set; }
        public int? Limit { get; set; } = 10;
        public int? Page { get; set; } = 1;
    }
}