using Quartz;

namespace Scheduler.Services.QuartzService.jobs;


public class TestJob : IJob
{
    private readonly ILogger<TestJob> _logger;

    public TestJob(
        ILogger<TestJob> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Publishing event {TestJob}", nameof(TestJob));
   
    }
}