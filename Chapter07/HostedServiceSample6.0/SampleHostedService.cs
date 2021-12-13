namespace HostedServiceSample;

public class SampleHostedService : IHostedService
{
    private readonly ILogger<SampleHostedService> logger;
    public SampleHostedService(ILogger<SampleHostedService> logger)
    {
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Hosted service starting");

        return Task.Factory.StartNew(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogInformation("Hosted service executing - {0}", DateTime.Now);
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                }
                catch (OperationCanceledException) { }
            }
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Hosted service stopping");
        return Task.CompletedTask;
    }
}

