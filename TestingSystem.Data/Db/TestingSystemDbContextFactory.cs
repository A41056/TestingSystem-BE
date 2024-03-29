using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TestingSystem.Data.Db;
public class TestingSystemDbContextFactory : IDesignTimeDbContextFactory<TestingSystemDbContext>
{
    public TestingSystemDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var connectionString = configuration.GetConnectionString("TestingSystemDb");

        var optionsBuilder = new DbContextOptionsBuilder<TestingSystemDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TestingSystemDbContext(optionsBuilder.Options);
    }
}
