using Microsoft.Extensions.DependencyInjection;
using Qualyteam.Application.Interfaces;
using Qualyteam.Data.Repositories;
using Qualyteam.Domain.Interfaces.Repository;
using Qualyteam.Domain.Services;
using AutoMapper;
using System;
using Qualyteam.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Qualyteam.Domain.Notifications;

namespace Qualyteam.IoC.InjectionDependencys
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Domain Services
            services.AddScoped<IIndicadorMensalService, IndicadorMensalService>();
            services.AddScoped<IColetaService, ColetaService>();

            // Domain Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infrastructure Repositories
            services.AddScoped<IIndicadorMensalRepository, IndicadorMensalRepository>();
            services.AddScoped<IColetaRepository, ColetaRepository>();

            // Infrastructure Data
            services.AddDbContext<QualyTeamContext>(opt => opt.UseInMemoryDatabase("DatabaseConnection"));
        }
    }
}
