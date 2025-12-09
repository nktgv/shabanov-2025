using Microsoft.EntityFrameworkCore;
using Npgsql;
using RESTFul.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Choose database provider (PostgreSQL by default, in-memory for local dev)
var useInMemory = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");
if (useInMemory)
{
    builder.Services.AddDbContext<Context>(options =>
        options.UseInMemoryDatabase("RestfulDb"));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("Database")
        ?? throw new InvalidOperationException("Connection string 'Database' not found.");

    builder.Services.AddDbContext<Context>(options =>
        options.UseNpgsql(connectionString));
}

var app = builder.Build();

// Automatically apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<Context>();

        if (useInMemory)
        {
            // In-memory provider needs explicit database creation
            context.Database.EnsureCreated();
            logger.LogInformation("In-memory database created.");
        }
        else
        {
            // Apply any pending migrations
            context.Database.Migrate();
            logger.LogInformation("Database migrations applied successfully.");
        }
    }
    catch (PostgresException ex)
    {
        logger.LogError(ex, "Database migration failed (provider: PostgreSQL). Check connection string and permissions.");
        throw;
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the database.");
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
