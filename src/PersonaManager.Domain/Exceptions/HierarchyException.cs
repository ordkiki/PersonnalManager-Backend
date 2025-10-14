using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Exceptions
{
    public class HierarchyException(string message, bool status, int code) : Exception(message)
    {
        public override string Message { get; } = message;
        public bool Success { get; set; } = status;
        public int Code { get; set; } = code;
    }
}
