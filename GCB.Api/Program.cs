using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GCB.Api
{
    public class Program
    {
        public static string Diretorio { get; private set; }

        public static void Main(string[] args)
        {
            Diretorio = Directory.GetCurrentDirectory();

            Console.Title = "Gerenciar Contas Bancarias API";

            Console.WriteLine("==========================================");
            Console.WriteLine(Diretorio);
            Console.WriteLine("==========================================");

            CreateHostBuilder(args)
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();

                    if (hostingContext.HostingEnvironment.IsDevelopment())
                        config.AddUserSecrets<Startup>(optional: true);

                    if (args != null) config.AddCommandLine(args);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
