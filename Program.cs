using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data;

namespace ToDo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //    CreateHostBuilder(args).Build().Run();
            var host = BuildWebHost(args);

            using ( var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CrudContext>();
                DbInitializer.Initialize(context);
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] agrs) =>
            WebHost.CreateDefaultBuilder(agrs)
            .UseStartup<Startup>()
            .Build();



    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Startup>();
    //            });
    }
}
