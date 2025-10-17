using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonaManager.Domain.Entities;
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
                identity.Property(x => x.Avatar);
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


			builder.OwnsOne(x => x.CivilStatus, civilStatus =>
			{
				civilStatus.Property(x => x.Spouse);
			});



			builder.Property(e => e.Identity).IsRequired();
            builder.Property(e => e.Identity).IsRequired();
            builder.Property(e => e.Identity).IsRequired();
            builder.Property(e => e.Identity).IsRequired();
            builder.Property(e => e.Identity).IsRequired();
            builder.Property(e => e.Identity).IsRequired();
		
        
            builder.HasAlternateKey(e => e.JobId);



		}
        
    }
}
