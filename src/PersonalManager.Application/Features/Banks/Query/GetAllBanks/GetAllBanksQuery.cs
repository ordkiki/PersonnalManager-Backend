using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Query.GetAllBanks
{
    public class GetAllBanksQuery : IRequest<GetAllBanksResponse>
    {
        public string? Search { get; set; } = string.Empty;
        public int? Limit { get; set; } = null;
        public int? Page { get; set; } = null;
    }
}
