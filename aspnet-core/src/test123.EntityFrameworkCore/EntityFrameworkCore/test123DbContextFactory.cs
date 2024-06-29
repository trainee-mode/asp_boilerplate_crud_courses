using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using test123.Configuration;
using test123.Web;

namespace test123.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class test123DbContextFactory : IDesignTimeDbContextFactory<test123DbContext>
    {
        public test123DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<test123DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            test123DbContextConfigurer.Configure(builder, configuration.GetConnectionString(test123Consts.ConnectionStringName));

            return new test123DbContext(builder.Options);
        }
    }
}
