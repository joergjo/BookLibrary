﻿using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace BookLibrary
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
                    webBuilder
                        .UseLamar()
                        .UseStartup<Startup>()
                        .UseApplicationInsights()
                        .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            var secretsPath = Path.Combine(
                                hostingContext.HostingEnvironment.ContentRootPath,
                                "secrets");
                            config.AddKeyPerFile(secretsPath, optional: true);
                        });
                });
    }
}
