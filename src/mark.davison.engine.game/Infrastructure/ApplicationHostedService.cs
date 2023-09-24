namespace mark.davison.engine.game.Infrastructure;

public class ApplicationHostedService : IHostedService
{
    private readonly IApplication _app;
    private readonly IServiceProvider _serviceProvider;

    public ApplicationHostedService(
        IApplication app,
        IServiceProvider serviceProvider)
    {
        _app = app;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _app.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _app.Stop();
        return Task.CompletedTask;
    }
}
