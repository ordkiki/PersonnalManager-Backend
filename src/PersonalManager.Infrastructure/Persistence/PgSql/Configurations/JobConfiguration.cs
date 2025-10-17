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

			builder.Property(c => c.JobTitle).IsRequired();
			builder.Property(c => c.JobCode).IsRequired();
		}
	}
}
