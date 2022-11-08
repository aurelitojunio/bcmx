using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Services
            services.AddSingleton<ICabecaService, CabecaService>();
            services.AddSingleton<IBracoEsquerdoService, BracoEsquerdoService>();
            services.AddSingleton<IBracoDireitoService, BracoDireitoService>();
            #endregion

            #region Repositories
            services.AddSingleton<ICabeca, Cabeca>();
            services.AddSingleton<IBracoEsquerdo, BracoEsquerdo>();
            services.AddSingleton<IBracoDireito, BracoDireito>();
            #endregion

            return services;
        }
    }
}
