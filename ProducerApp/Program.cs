using ProducerApp;
using ProducerApp.Configurations;
using ProducerApp.Utils;
//B3
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<AppProducerConfig>(context.Configuration.GetSection("Producer"));
        services.AddSingleton<AppProducer>();
    })
    .Build();

await host.RunAsync();
