using Domain.Model.Interfaces.Context;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Service;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Crosscutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHeroiRepository, HeroiSqlRepository>();
            services.AddScoped<IPoderRepository, PoderSqlRepository>();
            services.AddScoped<IHeroiService, HeroiService>();
            services.AddScoped<IPoderService, PoderService>();

            services.AddScoped<IAdoNetScopedContext, AdoNetScopedContext>();
        }
    }
}
