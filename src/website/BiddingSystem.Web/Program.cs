using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BiddingSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Log.Logger = new LoggerConfiguration().WriteTo.Sentry("sentryurl").CreateLogger();

            var configuration = new ConfigurationBuilder().AddCommandLine(args).Build();
// #if DEBUG
//             var hostUrl = configuration["hosturl"];
//             if (string.IsNullOrEmpty(hostUrl))
//                 hostUrl = "https://0.0.0.0:5001";
//             CreateWebHostBuilder(args).UseUrls(hostUrl).Build().Run();
// #endif
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>().UseSerilog();
    }
}
