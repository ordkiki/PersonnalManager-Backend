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
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee>
	{
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Matricule).IsRequired();
            builder.Property(e => e.Civility);

            builder.OwnsOne(x => x.Identity, identity => 
            {
                identity.Property(x => x.FirstName);
                identity.Property(x => x.LastName).IsRequired();
                identity.OwnsOne(x => x.Avatar, avatar =>
                {
                    avatar.Property(x => x.Extensions);
                    avatar.Property(x => x.Name);
                    avatar.Property(x => x.Url);
                    avatar.Property(x => x.ContentType);
                    avatar.Property(x => x.Size);
                });
                identity.Property(x => x.Nationality);
                identity.Property(x => x.BirthPlace);
                identity.Property(x => x.BirthDate);
                identity.Property(x => x.CIN);
                identity.Property(x => x.Gender);
			});

			builder.OwnsOne(x => x.Adress, adress =>
			{
				adress.Property(x => x.Street);
				adress.Property(x => x.Area);
				adress.Property(x => x.City);
				adress.Property(x => x.PostalCode);
				adress.Property(x => x.City);
				adress.Property(x => x.Country);
			});
			
            builder.OwnsOne(x => x.Contact, contact =>
			{
				contact.Property(x => x.PhoneNumber);
				contact.Property(x => x.Email);
			});

			builder.OwnsOne(x => x.CivilStatus, civilStatus =>
			{
				civilStatus.OwnsOne(x => x.Spouse, Identity =>
                {
                    Identity.OwnsOne(x => x.Avatar);
                });
			});


            builder.HasOne(e => e.Manager).WithMany().HasForeignKey(e => e.ManagerId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(e => e.Job).WithMany().HasForeignKey(e => e.JobId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Banks).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Children).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Contracts).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Children).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Educations).WithOne().OnDelete(DeleteBehavior.Cascade);
		}
        
    }
}
