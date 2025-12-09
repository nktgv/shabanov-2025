using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RESTFul.Infrastructure;

public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();

        // Use PostgreSQL for migrations
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=restful_db;Username=postgres;Password=restful_db_pass");

        return new Context(optionsBuilder.Options);
    }
}
