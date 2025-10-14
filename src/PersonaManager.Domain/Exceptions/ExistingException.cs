using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Exceptions
{
    public class ExistingException(string message, int statusCode, bool success) : Exception
    {
        public int StatusCode { get; } = statusCode;
        public override string Message { get; } = message;
        public bool Success { get; } = success;
    }
}
