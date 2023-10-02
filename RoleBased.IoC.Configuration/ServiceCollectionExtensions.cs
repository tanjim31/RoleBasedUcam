using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoleBased.Core;
using RoleBased.Core.Behavior;
using RoleBased.Core.Mapping;
using RoleBased.Infrastructure.Persistance;
using RoleBased.Repository.Concrete;
using RoleBased.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.IoC.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection MapCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RoleBasedDbContext>(option => option.UseSqlServer
            (configuration.GetConnectionString("default")));

            services.AddAutoMapper(typeof(MappingExtension).Assembly);
            services.AddTransient<IStudentRepository, StudentInfoRepository>();

            services.AddTransient<ILoginDBRepository, LoginDBRepository>();
            //services.AddTransient<IStateRepository, StateRepository>();

            services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });
            return services;
        }
    }
}

