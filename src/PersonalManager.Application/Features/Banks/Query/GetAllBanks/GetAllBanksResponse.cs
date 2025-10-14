using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Banks.Query.GetAllBanks
{
    public class GetAllBanksResponse
    {
        public IEnumerable<Bank>? Data { get; set; } = [];
        public long? Total { get; set; }
        public int? TotalPage { get; set; }
    }
}
