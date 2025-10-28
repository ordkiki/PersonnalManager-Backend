using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Entities;
using PersonaManager.Domain.ValuesObject;
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

			builder.Property(d => d.DepartmentName).IsRequired(true);
			builder.Property(d => d.DepartmentCode).IsRequired(false);
			builder.Property(d => d.ParentDepartmentId);
			builder.HasIndex(d => d.DepartmentCode);

            builder.HasMany(e => e.DepartmentsFils)
                    .WithOne()
                    .HasForeignKey(d => d.ParentDepartmentId).IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
