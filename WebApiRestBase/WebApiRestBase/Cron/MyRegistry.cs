using FluentScheduler;
using WebApiRestBase.Cron.Jobs;

namespace WebApiRestBase.Cron
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<MyJob>().ToRunNow().AndEvery(5).Seconds();
        }
    }
}