using Microsoft.Extensions.DependencyInjection;
using Qualyteam.Application.Interfaces;
using Qualyteam.Data.Repositories;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Services;
using AutoMapper;
using System;

namespace Qualyteam.IoC.InjectionDependencys
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Services
            services.AddScoped<IIndicadorMensalService, IndicadorMensalService>();
            services.AddScoped<IColetaService, ColetaService>();

            // Repositories
            services.AddScoped<IIndicadorMensalRepository, IndicadorMensalRepository>();
            services.AddScoped<IColetaRepository, ColetaRepository>();
        }
    }
}
