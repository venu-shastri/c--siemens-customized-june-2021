using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionInAction.Extensibility;
namespace DependencyInjectionInAction
{

    
    public class Program
    {
      
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).
            ConfigureAppConfiguration((hostBuilderContext, configBuilder) => {
                // configBuilder.Sources.Clear();
                configBuilder.AddJsonFile("MyAppConfig.json");
                configBuilder.AddMongo("vvvv");
                configBuilder.AddCsvFile("test.csv");
      
            })
           .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
