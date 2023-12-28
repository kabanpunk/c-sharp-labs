using System;
using System.Threading;
using System.Threading.Tasks;
using ExperimentLibrary;
using Microsoft.Extensions.Hosting;
using StrategiesLibrary;

namespace GenericHostApp
{
    public class ColiseumExperimentWorker : IHostedService
    {
        private readonly CardChoosingExperiment _experiment;
        private readonly IPartnerStrategy _strategy1;
        private readonly IPartnerStrategy _strategy2;
        private bool _running;

        public ColiseumExperimentWorker(CardChoosingExperiment experiment,
            IPartnerStrategy strategy1,
            IPartnerStrategy strategy2)
        {
            _experiment = experiment;
            _strategy1 = strategy1;
            _strategy2 = strategy2;
            _running = true;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _running = true;
            return Task.Run(() =>
            {
                int successCount = 0;
                int totalExperiments = 1000000;

                for (int i = 0; _running && i < totalExperiments; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    if (_experiment.ConductExperiment(_strategy1, _strategy2))
                    {
                        successCount++;
                    }
                }

                Console.WriteLine($"Успехов: {successCount} из {totalExperiments}");
                Console.WriteLine($"Вероятность успеха: {(double)successCount / totalExperiments:P2}");
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _running = false;
            Console.WriteLine("Эксперименты останавливаются.");
            return Task.CompletedTask;
        }
    }
}
