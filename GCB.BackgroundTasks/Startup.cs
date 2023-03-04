using GCB.Comum.Extensoes;
using GCB.Infraestrutura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.SqlServer;
using System;
using GCB.Dominio.Repositorios;
using GCB.Infraestrutura.Repositorios;
using GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia;
using MediatR;
using FluentValidation;
using GCB.Infraestrutura.Extensoes;

namespace GCB.BackgroundTasks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithFilters();

            services.AddMediatR(typeof(AdicionarReferenciaCommand).Assembly);
            
            services.AddValidatorsFromAssembly(typeof(AdicionarReferenciaValidator).Assembly);

            services.AddMediatRBehaviours();

            services.AddDbContext<GerenciarContasBancariasContext>(Configuration, typeof(GerenciarContasBancariasContext).Assembly.FullName);

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration["HangfireConnectionString"], new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer();

            services.AddCoreServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseHangfireDashboard();

            HangfireJobScheduler.ScheduleRecurringJobs();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHangfireDashboard();
            });
        }
    }
}
