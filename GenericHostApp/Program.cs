using System;
using System.Threading.Tasks;
using CoreLibrary;
using GenericHostApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StrategiesLibrary;

namespace GenericHostApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Запускаем хост
            await host.RunAsync();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Регистрация зависимостей
                    services.AddScoped<IDeckShuffler, DeckShuffler>();
                    services.AddScoped<ExperimentLibrary.CardChoosingExperiment>();
                    services.AddScoped<IPartnerStrategy, SimpleStrategy>(); // Пример стратегии

                    // Регистрация HostedService
                    services.AddHostedService<ColiseumExperimentWorker>();
                });
        }

 
    }
}