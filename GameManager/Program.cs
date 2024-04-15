using GameManager;
using GameManager.Consumers;
using MassTransit;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddMassTransit(x =>
    {
        x.AddConsumer<MatchWaitingForGameConsumer>();
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);
        });
    });
});

var host = builder.Build();
host.Run();
