using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalManager.Infrastructure.Persistence.PgSql.Contexts;
using PersonalManager.Infrastructure.Persistence.PgSql.Repository;
using PersonalManager.Infrastructure.Persistence.PgSql.Services;
using PersonaManager.Domain.Interfaces.Repository;
using PersonaManager.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Infrastructure.Commons.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //ConnectionStrings(Database)
            services.AddDbContext<PgSqlContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            //Repository & UOW & Service
            services.AddScoped(typeof(IRepositoryCommand<>), typeof(RepositoryCommand<>));
            services.AddScoped(typeof(IRepositoryQuery<>), typeof(RepositoryQuery<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
