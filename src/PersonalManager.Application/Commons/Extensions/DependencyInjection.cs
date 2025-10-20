using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalManager.Application.Commons.Behaviors;
using PersonalManager.Application.Commons.Utils;
using PersonalManager.Application.Features.Banks.Command.CreateBank;
using PersonalManager.Application.Features.Banks.Query.GetAllBanks;
using PersonalManager.Application.Features.Children.Command.CreateChild;
using PersonalManager.Application.Features.Jobs.Command.CreateJob;
using PersonaManager.Domain.Interfaces.Services;
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
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllBanksQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateBankCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateJobCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateChildCommand).Assembly);
            });

            services.AddScoped<ICodeGenerator, CodeGenerator>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
