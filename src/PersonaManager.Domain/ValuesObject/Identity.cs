using PersonaManager.Domain.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaManager.Domain.ValuesObject
{
    public class Identity
    {
        private string? _lastName;
        private string _firstName = string.Empty;
        public Resource? Avatar { get; set; }
        public string? LastName 
        { 
            get => _lastName; 
            set => _lastName = value?.ToUpper();
        }
        public required string FirstName 
        { 
            get => _firstName; 
            set => _firstName = value.ToTitleCase();
        }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? CIN { get; set; }
        public string? Nationality { get; set; }
    }
}