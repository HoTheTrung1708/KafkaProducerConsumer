using Confluent.Kafka;
using Microsoft.Extensions.Options;
using ProducerApp.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerApp.Utils
{
    public class AppProducer
    {
        private readonly string _topic;
        private readonly IProducer<string, string> _producer;

        public AppProducer(IOptions<AppProducerConfig> options) 
        { 
            var appProducerConfig = options.Value;
            var producerConfig = appProducerConfig.GetProducerConfig();
            _topic = appProducerConfig.Topic;
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        public void Produce(int key, string value)
        {
            var message = new Message<string, string> { Key = key.ToString(), Value = value };
            _producer.Produce(_topic, message);
        }

        public async Task ProduceAsync(int key, string value)
        {
            var message = new Message<string, string> { Key = key.ToString(), Value = value };
            await _producer.ProduceAsync(_topic, message);
        }
    }
}
