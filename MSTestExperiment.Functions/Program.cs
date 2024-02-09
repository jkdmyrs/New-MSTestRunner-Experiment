using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

Mutex? functionStartup = null;
try
{
    IHostApplicationLifetime hostApplicationLifetime = (IHostApplicationLifetime)host.Services.GetRequiredService(typeof(IHostApplicationLifetime));
    hostApplicationLifetime.ApplicationStarted.Register(() =>
    {
        functionStartup = new(true, "FunctionStartup");
    });

    host.Run();
}
finally
{
    functionStartup?.Dispose();
}