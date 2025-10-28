using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Configurations
{
    public class JobConfiguration : BaseEntityConfiguration<Job>
    {
		public override void Configure(EntityTypeBuilder<Job> builder)
		{
			base.Configure(builder);

			builder.Property(c => c.JobTitle).IsRequired(true);
			builder.Property(c => c.JobCode).IsRequired(false);
			builder.Property(c => c.DepartementId).IsRequired(false);

            builder.HasOne(e => e.Departments)
                          .WithMany()
                          .HasForeignKey(e => e.DepartementId)
                          .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
