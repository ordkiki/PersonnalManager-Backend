using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Children.Query.GetAllChildren
{
    public class GetAllChildrenQuery : IRequest<GetAllChildResponse>
    {
        public string? Search { get; set; }
        public int? Limit { get; set; }
        public int? Page { get; set; }
        public string? OrderBy { get; set; }
        public bool? SortazAZ { get; set; }
        public bool? Dependent { get; set; }
        public string? ParentName { get; set; }
    }
}
