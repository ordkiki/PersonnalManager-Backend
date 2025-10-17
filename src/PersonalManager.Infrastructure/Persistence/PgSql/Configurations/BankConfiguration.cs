using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Configurations
{
    public class BankConfiguration : BaseEntityConfiguration<Bank>
    {
        public override void Configure(EntityTypeBuilder<Bank> builder)
        {
            base.Configure(builder);
            builder.Property(b => b.Rib).IsRequired();
            builder.Property(b => b.Iban).IsRequired();
            builder.Property(b => b.AccountLabel);
            builder.Property(b => b.Bic);
            builder.Property(b => b.IsDeleted);
            builder.Property(b => b.CountryCode);
			builder.Property(b => b.EmployeeId);
            
            builder.HasAlternateKey(b => b.EmployeeId);
        }
	}
}
