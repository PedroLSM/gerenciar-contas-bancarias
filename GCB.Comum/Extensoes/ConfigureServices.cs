using GCB.Comum.Comportamentos;
using GCB.Comum.Factories;
using GCB.Comum.Filtros;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GCB.Comum.Extensoes
{
    public static class ConfigureServices
    {
        public static void AddDbContext<T>(
            this IServiceCollection services, 
            IConfiguration configuration, 
            string migrationAssembly,
            string connectionStringName = "ConnectionString"
            )
            where T : DbContext
        {
            services.AddTransient<ISqlConnectionFactory>(s => new SqlConnectionFactory(configuration[connectionStringName]));

            services.AddDbContext<T>(options =>
                options.UseSqlServer(
                    configuration[connectionStringName],
                    sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)
                )
            );
        }

        public static IMvcBuilder AddControllersWithFilters(this IServiceCollection services)
        {
            return services.AddControllers(
                options => options.Filters.Add(new ApiExceptionFilter())
            );
        }

        public static void AddMediatRBehaviours(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        }

        public static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services, string apiTile = "GCB API")
        {
            services.AddOpenApiDocument(cfg =>
            {
                cfg.PostProcess = d => d.Info.Title = apiTile;
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();

            return app;
        }

        public static IServiceCollection AddDefaultCors(this IServiceCollection services)
        {
            services.AddCors(option => 
                option.AddDefaultPolicy(policies => 
                    policies.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    )
                );

            return services;
        }

        public static IApplicationBuilder UseDefaultCors(this IApplicationBuilder app)
        {
            app.UseCors();

            return app;
        }
    }
}
