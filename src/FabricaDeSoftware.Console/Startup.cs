using FabricaDeSoftware.Data.Repository;
using FabricaDeSoftware.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;

namespace FabricaDeSoftware.ConsoleApp
{

    public class Startup
    {
        public void BuilderApp(IConfiguration configuration)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if (string.IsNullOrWhiteSpace(environment))
            //    throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            //Console.WriteLine("Environment: {0}", environment);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);
            //if (environment == "Development")
            //{

            //    builder
            //        .AddJsonFile(
            //            Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.{environment}.json"),
            //            optional: true
            //        );
            //}
            //else
            //{
            //    builder
            //        .AddJsonFile($"appsettings.{environment}.json", optional: false);
            //}

            configuration = builder.Build();
        }

        public void AplicarDependencias(IConfiguration configuration)
        {
            var services = new ServiceCollection();

            services.AddSingleton(
                _ => configuration);

            services.AddScoped<ICalculoDAO, CalculoDAO>();
        }
    }
}
