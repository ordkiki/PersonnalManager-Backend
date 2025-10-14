using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.ValuesObject
{
    public record Resource
    {
        public string? Name { get; set; }
        public string? Extensions { get; set; }
        public string? ContentType { get; set; }
        public int? Size { get; set; }
        public string? Url { get; set; }
    }
}
