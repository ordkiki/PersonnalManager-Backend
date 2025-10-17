using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Configurations
{
	public class DepartmentConfiguration : BaseEntityConfiguration<Department>
	{
		public override void Configure(EntityTypeBuilder<Department> builder)
		{
			base.Configure(builder);

			builder.Property(d => d.DepartmentName).IsRequired();
			builder.Property(d => d.DepartmentCode);
		}
	}
}
