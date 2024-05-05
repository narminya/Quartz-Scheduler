using Scheduler.Services.QuartzService;

namespace Scheduler;

public static class DependencyInjection
{
    public static IServiceCollection AddQuartzJob<TService>(this IServiceCollection services, string cronExpression) where TService : class
    {
        var options = new CronExpressionDescriptor.Options()
        {
            ThrowExceptionOnParseError = false,
            Verbose = false,
            DayOfWeekStartIndexZero = true,
        };
        string description = CronExpressionDescriptor.ExpressionDescriptor.GetDescription(cronExpression, options);
       // logger.LogInformation("Added {job} scheduled {cronDescription}", typeof(TService).Name, description);
        return services.AddScoped<TService>().AddSingleton(new JobSchedule(jobType: typeof(TService), cronExpression: cronExpression));
    }
}