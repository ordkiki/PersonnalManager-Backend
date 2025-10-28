using MediatR;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Query.GetAllEmployees
{
    public class GetAllEmployeeQuery : IRequest<GetAllEmployeeQueryResponse>
    {
        public string? Search { get; set; }
        public int? Limit { get; set; } = 10;
        public int? Page { get; set; } = 1;
        public string? OrderBy { get; set; }
        public bool? SortazAZ { get; set;}
        public bool? IsDeleted { get; set;}
        public string? JobTitle {  get; set; }
        public EmployeeStatus? Status {  get; set; }
        public string? DepartmentName {  get; set; }
    }
}