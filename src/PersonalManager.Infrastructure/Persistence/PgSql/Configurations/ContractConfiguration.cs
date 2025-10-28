using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contrat =  PersonaManager.Domain.Entities.Contract;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Configurations
{
    public class ContractConfiguration : BaseEntityConfiguration<Contrat>
    {
        public override void Configure(EntityTypeBuilder<Contrat> builder)
        {
            base.Configure(builder);
           
                builder.Property(c => c.SalaryMensual);
                builder.Property(c => c.TypeContrat).IsRequired(true);
                builder.Property(c => c.StartDate).IsRequired(false);
                builder.Property(c => c.EndDate).IsRequired(false);
                builder.Property(c => c.ContratReference).IsRequired(false);
                builder.Property(c => c.SalaryMensual).IsRequired(false);
                builder.Property(c => c.EmployeeId).IsRequired(true);
                builder.HasOne(c => c.Employee).WithMany().HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
