using AppConsumer;
using AppConsumer.Utils;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context , services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<AppConsumerConfig>(context.Configuration.GetSection("Consumer"));
        services.AddSingleton<AppKafkaConsumer>();
    })
    .Build();

await host.RunAsync();
