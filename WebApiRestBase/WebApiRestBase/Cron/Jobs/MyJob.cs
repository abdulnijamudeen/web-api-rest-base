using FluentScheduler;
using System.Diagnostics;

namespace WebApiRestBase.Cron.Jobs
{
    public class MyJob : IJob
    {
        public void Execute()
        {
            Debug.WriteLine("FluentScheduler Running");
        }
    }
}