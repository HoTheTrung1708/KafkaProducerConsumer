using AppConsumer.Utils;

namespace AppConsumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppKafkaConsumer _consumer; 

        public Worker(ILogger<Worker> logger, AppKafkaConsumer consumer)
        {
            _logger   = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe();
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = _consumer.Consume();
               if(result  != null)
                {
                    _logger.LogInformation($"Consumer message offset {result.Offset}, " +
                        $"key {result.Message.Key}, value: {result.Message.Value}");
                    _consumer.Commit(result);
                }
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}