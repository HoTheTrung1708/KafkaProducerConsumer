using Confluent.Kafka;
class Program
{
    static void Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost" };
        var producer = new ProducerBuilder<Null, string>(config).Build();

        for (int i = 0; i < 10; ++i)
        {
            producer.Produce("users", new Message<Null, string> { Value = $"Hello, Kafka user! ({i})" });
        }

        producer.Flush(TimeSpan.FromSeconds(10));
        Console.WriteLine("Produced 10 messages to topic users");

        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = "localhost",
            GroupId = "group1",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        consumer.Subscribe("users");
        try
        {
            while (true)
            {
                var result = consumer.Consume(TimeSpan.FromSeconds(1));
                if (result == null)
                {
                    continue;
                }
                Console.WriteLine($"Consumed message '{result.Message.Value}' at: '{result.TopicPartitionOffset}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}