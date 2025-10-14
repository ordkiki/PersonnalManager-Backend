using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.ValuesObject
{
    public class CivilStatus
    {
        [Column(TypeName = "text")]
        public Identity? Spouse { get; set; }
    }
}