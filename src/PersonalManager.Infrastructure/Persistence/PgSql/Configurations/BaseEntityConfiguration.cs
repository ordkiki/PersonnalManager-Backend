using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Configurations
{
	public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.CreatedAt)
				.IsRequired()
				//.HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.UpdatedAt);
			builder.Property(x => x.IsDeleted).IsRequired(false).ValueGeneratedOnAdd();
			
		}
	}
}
