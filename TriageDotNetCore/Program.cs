using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TriageDotNetCore.Models.Db;

namespace TriageDotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
	            IServiceProvider services = scope.ServiceProvider;

	            try
	            {
		            var dbContext = services.GetRequiredService<EmployeeDbContext>();
		            DbInitializer.Initialize(dbContext);
	            }
	            catch (Exception ex)
	            {
		            var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
	            }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
