using System;
using Topshelf;

namespace DataAssemblyLine.CoordinatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<SchedulingService>(s =>
                {
                    s.ConstructUsing(name => new SchedulingService());
                    s.WhenStarted(ss => ss.StartAsync().Wait());
                    s.WhenStopped(ss => ss.StopAsync());
                });
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
