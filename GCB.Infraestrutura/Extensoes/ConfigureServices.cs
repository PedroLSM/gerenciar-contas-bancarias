using GCB.Dominio.Repositorios;
using GCB.Dominio.Servicos;
using GCB.Infraestrutura.Repositorios;
using GCB.Infraestrutura.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace GCB.Infraestrutura.Extensoes
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICSVServico, CSVServico>();

            return services;
        }
    }
}
