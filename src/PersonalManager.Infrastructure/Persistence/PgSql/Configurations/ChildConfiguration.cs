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
    public class ChildConfiguration : BaseEntityConfiguration<Child>
    {
        public override void Configure(EntityTypeBuilder<Child> builder)
        {
            base.Configure(builder);
            builder.OwnsOne(x => x.Identity, child => {
                child.Property(identity => identity.LastName).IsRequired(true);
                child.Property(identity => identity.FirstName).IsRequired(false);
                child.Property(identity => identity.Nationality).IsRequired(false);
                child.Property(identity => identity.Nationality).IsRequired(false);
                child.Property(identity => identity.BirthDate).IsRequired(false);
                child.Property(identity => identity.BirthPlace).IsRequired(false);
                builder.OwnsOne(x => x.Identity, identity =>
                {
                    identity.OwnsOne(x => x.Avatar, resource =>
                    {
                        resource.Property(r => r.Extensions);
                        resource.Property(r => r.ContentType);
                        resource.Property(r => r.Url);
                        resource.Property(r => r.Size);
                        resource.Property(r => r.Name);
                    });
                });

            });

            builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.Id).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Educations).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}