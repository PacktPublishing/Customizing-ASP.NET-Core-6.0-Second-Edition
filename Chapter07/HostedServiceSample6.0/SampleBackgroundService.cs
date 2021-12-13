namespace HostedServiceSample;

public class SampleBackgroundService : BackgroundService
{
    private readonly ILogger<SampleHostedService> logger;
    public SampleBackgroundService(ILogger<SampleHostedService> logger)
    {
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Background service starting");

        await Task.Factory.StartNew(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Background service executing - {0}", DateTime.Now);
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                }
                catch (OperationCanceledException) { }
            }
        }, cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Background service stopping");
        await Task.CompletedTask;
    }
}
