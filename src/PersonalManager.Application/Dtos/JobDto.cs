using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalManager.Application.Dtos
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string? JobCode { get; set; }
        public required string JobTitle { get; set; }

        public Guid? DepartementId { get; set; }
    }
}
