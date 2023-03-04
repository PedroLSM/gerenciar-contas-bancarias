using FluentValidation;
using GCB.Aplicacao.Comandos.Referencias.AdicionarReferencia;
using GCB.Comum.Extensoes;
using GCB.Dominio.Repositorios;
using GCB.Dominio.Servicos;
using GCB.Infraestrutura;
using GCB.Infraestrutura.Extensoes;
using GCB.Infraestrutura.Repositorios;
using GCB.Infraestrutura.Servicos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GCB.Api
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
            services.AddControllersWithFilters()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddDefaultCors();

            services.AddMediatR(typeof(AdicionarReferenciaCommand).Assembly);

            services.AddValidatorsFromAssembly(typeof(AdicionarReferenciaValidator).Assembly);

            services.AddMediatRBehaviours();

            services.AddDbContext<GerenciarContasBancariasContext>(Configuration, typeof(GerenciarContasBancariasContext).Assembly.FullName);

            services.AddOpenApiDocumentation();

            services.AddCoreServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseDefaultCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
