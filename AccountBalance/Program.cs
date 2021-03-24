using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Logging;
using Steeltoe.Extensions.Configuration.Placeholder;
using Steeltoe.Management.Endpoint;

namespace AccountBalance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging((context, builder) => builder.AddDynamicConsole());
                    webBuilder.AddAllActuators();
                    webBuilder.AddPlaceholderResolver();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
