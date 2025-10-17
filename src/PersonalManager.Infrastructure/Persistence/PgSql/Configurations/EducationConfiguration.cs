using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Persistence.PgSql.Configurations
{
    public class EducationConfiguration : BaseEntityConfiguration<Education>
    {
        public override void Configure(EntityTypeBuilder<Education> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Establishment).IsRequired();
            builder.Property(e => e.FieldOfStudy).IsRequired();
            builder.Property(e => e.GraduationYear);
            builder.Property(e => e.Graduation).IsRequired();
        }
    }
}