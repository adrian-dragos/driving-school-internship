using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance;
using System;
using System.Linq;

namespace IntegrationTests.Configuration
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        private SqliteConnection _connection;

        public CustomWebApplicationFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescriptor = services.SingleOrDefault(d =>
                    d.ServiceType ==
                        typeof(DbContextOptions<ApplicationContext>));

                services.Remove(serviceDescriptor);



                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkSqlite()
                        .BuildServiceProvider();


                services.AddDbContextFactory<ApplicationContext>(options =>
                    {
                        options.UseSqlite(_connection);
                        options.UseInternalServiceProvider(serviceProvider);
                    }
                    );

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var db = scopedServices.GetRequiredService<ApplicationContext>();

                    db.Database.EnsureDeleted();

                    db.Database.EnsureCreated();
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _connection.Close();
            _connection.Dispose();
        }
    }
}
