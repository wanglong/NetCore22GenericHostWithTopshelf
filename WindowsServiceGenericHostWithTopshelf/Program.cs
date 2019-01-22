using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Topshelf;

namespace WindowsServiceGenericHostWithTopshelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Windows Service Generic Host With Topshelf!");
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IHostLifetime, TopshelfLifetime>();
                    services.AddHostedService<FileWriterService>();
                });

            HostFactory.Run(x =>
            {
                x.SetServiceName("WindowsServiceGenericHostWithTopshelf");
                x.SetDisplayName("Topshelf创建的Generic Host服务");
                x.SetDescription("运行Topshelf创建的Generic Host服务");
                x.Service<IHost>(s =>
                {
                    s.ConstructUsing(() => builder.Build());
                    s.WhenStarted(service =>
                    {
                        service.StartAsync();
                    });
                    s.WhenStopped(service =>
                    {
                        service.StopAsync();
                    });
                });
            });
        }
    }
}
