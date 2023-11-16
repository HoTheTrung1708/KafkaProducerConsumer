using AppConsumer.Configurations;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsumer.Utils
{
    public class AppKafkaConsumer
    {//Viết hàm 
        private readonly IConsumer<string, string> _consumer;
        private readonly string _topic;

        public AppKafkaConsumer(IOptions<AppConsumerConfig> options) { 
            var appConsumerConfig = options.Value;
            var consumerConfig    = appConsumerConfig.GetConsumerConfig();
            _consumer             = new ConsumerBuilder<string, string>(consumerConfig).Build();
            _topic                = appConsumerConfig.Topic;
        } 
          

        public void Subscribe()
        {
            _consumer.Subscribe(_topic);
        }

        public ConsumeResult<string, string> Consume() => _consumer.Consume();

        public void Commit(ConsumeResult<string, string> result) => _consumer.Commit(result);
    }
}
