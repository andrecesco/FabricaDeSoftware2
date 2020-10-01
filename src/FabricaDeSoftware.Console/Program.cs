using FabricaDeSoftware.Core.Bus;
using FabricaDeSoftware.Data;
using FabricaDeSoftware.Data.Repository;
using FabricaDeSoftware.Domain;
using FabricaDeSoftware.Domain.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FabricaDeSoftware.ConsoleApp
{
    public static class Program
    {
        public static IConfigurationRoot Configuration;

        public static Guid IdUsuario = Guid.Parse("3718b09d-ae84-44a9-8a86-17b6f3e9a9f6");
        public static Guid IdConfiguracao = Guid.Parse("e1a3bcb0-a8d3-4bac-ba17-5bc1613b673c");

        public static ICalculoDAO _calculoDAO;
        public static ICalculoService _calculoService;

        private static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);

            Configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(provider => Configuration);

            services.AddScoped<ICalculoDAO, CalculoDAO>();
            services.AddScoped<ICalculoService, CalculoService>();

            services.AddMediatR(typeof(Program));
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            services.AddScoped<INotificationHandler<CalculoRealizadoEvent>, CalculoEventHandler>();

            var serviceProvider = services.BuildServiceProvider();

            _calculoDAO = serviceProvider.GetService<ICalculoDAO>();
            _calculoService = serviceProvider.GetService<ICalculoService>();

            Processamento();
        }

        private static void Processamento()
        {
            var listaFilaCalculo = _calculoDAO.ObterFilaCalculos().Result;

            if (listaFilaCalculo?.Count() > 0)
            {
                Console.WriteLine("ID | DistanciaDaReta | QuantidadeDePilares | QuantidadeDePilaresReforcados | PilaresComBaseReforcada | DistanciaEntreVaos | DataCadastro");
                foreach (var item in listaFilaCalculo)
                {
                    Console.WriteLine($"{item.Id} | {item.DistanciaDaReta} | {item.QuantidadeDePilares} | {item.QuantidadeDePilaresReforcados}, {item.PilaresComBaseReforcada} | {item.DistanciaEntreVaos} | {item.DataCadastro}");
                }

                Console.WriteLine("Deseja processar a Fila de Cálculos? (S/N)");
                string desejaProcessar = Console.ReadLine();

                if (desejaProcessar.Equals("S", StringComparison.CurrentCultureIgnoreCase))
                {
                    _calculoService.ProcessarFila().Wait();

                    Console.WriteLine($"Fila processada com sucesso. {listaFilaCalculo.Count()} processados com sucesso");

                    foreach (var item in _calculoDAO.ObterCalculos().Result)
                    {
                        Console.WriteLine($"{item.Id} | {item.DistanciaDaReta} | {item.QuantidadeDePilares} | {item.QuantidadeDePilaresReforcados}, {item.PilaresComBaseReforcada} | {item.DistanciaEntreVaos} | {item.DataCadastro}");
                    }
                }
            }

            Console.WriteLine("Fim do processo");
        }
    }
}
