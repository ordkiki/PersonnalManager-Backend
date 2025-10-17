using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Features.Employees.Query.GetOneEmployees
{
    public class GetOneEmployeeQuery : IRequest<GetOneEmployeeResponse>
    {
        public string? Term { get; set; }        
    }
}