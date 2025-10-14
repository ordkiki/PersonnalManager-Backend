using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalManager.Application.Commons.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Application.Commons.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Features.Banks.Query.GetAllBanks.GetAllBanksQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(Features.Banks.Command.CreateBank.CreateBankCommand).Assembly);
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
