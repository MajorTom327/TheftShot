using System;
using Topshelf;

namespace TheftShot
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<TSService>(s =>
                {
                    s.ConstructUsing(name => new TSService());
                    s.WhenStarted(ts => ts.Start());
                    s.WhenStopped(ts => ts.Stop());
                });
                x.RunAsLocalSystem();

                x.StartAutomatically();

                x.SetDescription("TheftShot Service");
                x.SetDisplayName("TheftShot");
                x.SetServiceName("TheftShot");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;

            var camera = new TSCamera();
        }
    }
}
