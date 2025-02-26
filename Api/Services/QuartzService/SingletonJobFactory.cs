using Quartz;
using Quartz.Spi;

namespace Scheduler.Services.QuartzService;

public class SingletonJobFactory : IJobFactory
{
    private readonly IServiceProvider _serviceProvider;
    public SingletonJobFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) 
    {
        return _serviceProvider.GetRequiredService<QuartzJobRunner>() as IJob;
    }

    public void ReturnJob(IJob job) { }
}