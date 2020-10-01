using FabricaDeSoftware.Core.Bus;
using FabricaDeSoftware.Data.Repository;
using FabricaDeSoftware.Domain;
using FabricaDeSoftware.Domain.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FabricaDeSoftware.App
{
    public static class Startup
    {
        public static IConfigurationRoot Configuration;

        public static Guid IdUsuario = Guid.Parse("3718b09d-ae84-44a9-8a86-17b6f3e9a9f6");
        public static Guid IdConfiguracao = Guid.Parse("e1a3bcb0-a8d3-4bac-ba17-5bc1613b673c");

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

            services.AddMediatR(typeof(Startup));
            //services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            services.AddScoped<INotificationHandler<CalculoRealizadoEvent>, CalculoEventHandler>();

            var serviceProvider = services.BuildServiceProvider();

            var calculoDAO = serviceProvider.GetService<ICalculoDAO>();
            var mediator = serviceProvider.GetService<IMediatrHandler>();
            var calculoService = serviceProvider.GetService<ICalculoService>();

            Application.Run(new ListaCalculos(calculoDAO, calculoService));

            //Console.WriteLine("ID | DistanciaDaReta | QuantidadeDePilares | QuantidadeDePilaresReforcados | PilaresComBaseReforcada | DistanciaEntreVaos | DataCadastro");
            //foreach (var item in calculoDAO.ObterCalculos())
            //{
            //    Console.WriteLine($"{item.Id} | {item.DistanciaDaReta} | {item.QuantidadeDePilares} | {item.QuantidadeDePilaresReforcados}, {item.PilaresComBaseReforcada} | {item.DistanciaEntreVaos} | {item.DataCadastro}");
            //}

            //Console.WriteLine("Informe a distância da reta?");
            //string strDistanciaDaReta = Console.ReadLine();

            //int.TryParse(strDistanciaDaReta, out int distanciaDaReta);

            //var calculo = new Calculo(IdConfiguracao, IdUsuario, distanciaDaReta);

            //var calculoService = new CalculoService(calculoDAO, mediator);
            //calculoService.RealizarCalculo(calculo).Wait();

            //Console.WriteLine($"{calculo.Id} | {calculo.DistanciaDaReta} | {calculo.QuantidadeDePilares} | {calculo.QuantidadeDePilaresReforcados} | {calculo.PilaresComBaseReforcada} | {calculo.DistanciaEntreVaos} | {calculo.DataCadastro}");

            //Console.WriteLine("Deseja salvar esse Cálculo? (S/N)");
            //string desejaSalvar = Console.ReadLine();

            //if (desejaSalvar.Equals("S", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    calculoDAO.SalvarCalculo(calculo);
            //    Console.WriteLine("Registro salvo com sucesso");

            //    foreach (var item in calculoDAO.ObterCalculos())
            //    {
            //        Console.WriteLine($"{item.Id} | {item.DistanciaDaReta} | {item.QuantidadeDePilares} | {item.QuantidadeDePilaresReforcados}, {item.PilaresComBaseReforcada} | {item.DistanciaEntreVaos} | {item.DataCadastro}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Registro descartado");
            //}
        }
    }
}
