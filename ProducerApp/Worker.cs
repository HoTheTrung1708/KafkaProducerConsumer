using ProducerApp.Utils;

namespace ProducerApp
{//B4 
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppProducer _appProducer;
        private int _counter = 0;

        public Worker(ILogger<Worker> logger, AppProducer appProducer)
        {
            _logger = logger;
            _appProducer = appProducer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _appProducer.Produce(++_counter, Guid.NewGuid().ToString());
                _logger.LogInformation($"Produced message {_counter}");
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}