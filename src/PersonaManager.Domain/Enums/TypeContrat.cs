using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonaManager.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeContrat
    {
        CDD, 
        CDI, 
        INTERIM, 
        STAGE, 
        INTERNSHIP, 
        FREELANCE, 
        PARTTIME, 
        SEASONAL, 
        CONSULTANT, 
        INTERNATIONNALVOLUNTEER
    }
}
