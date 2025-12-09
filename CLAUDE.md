# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET 9.0 ASP.NET Core Web API project following a three-tier architecture pattern with clean separation of concerns.

## Architecture

The solution consists of three projects:

- **RESTFul.API** - Web API layer (entry point)
- **RESTFul.Domain** - Domain entities and business models
- **RESTFul.Infrastructure** - Data access layer with Entity Framework Core

### Project Dependencies

- RESTFul.API depends on both Domain and Infrastructure
- RESTFul.Infrastructure depends on Domain
- RESTFul.Domain has no dependencies (pure domain layer)

### Database

- Database: PostgreSQL
- ORM: Entity Framework Core 9.0.9 with Npgsql
- Connection string configured in `appsettings.json`
- DbContext: `RESTFul.Infrastructure.Context` registered in Program.cs
- **Auto-migrations**: Database schema is automatically created/updated on application startup

## Development Commands

### Setup PostgreSQL Connection

Update the connection string in `RESTFul.API/appsettings.json`:
```json
"ConnectionStrings": {
  "Database": "Host=localhost;Port=5432;Database=restful_db;Username=postgres;Password=your_password"
}
```

### Build
```bash
dotnet build
```

### Run the application
```bash
dotnet run --project RESTFul.API/RESTFul.API.csproj
```

**Note**: The application automatically creates the database and applies all migrations on startup. No manual migration commands needed.

### Manual Database migrations (optional)
```bash
# Create a new migration
dotnet ef migrations add <MigrationName> --project RESTFul.Infrastructure --startup-project RESTFul.API

# Remove last migration
dotnet ef migrations remove --project RESTFul.Infrastructure --startup-project RESTFul.API
```

### Test
```bash
dotnet test
```

## Key Implementation Details

- OpenAPI/Swagger enabled in Development environment (mapped at `/openapi/v1.json`)
- Controllers use attribute routing
- HTTPS redirection enabled
- Authorization middleware configured (but not yet implemented)
- Entity Framework Core DbContext registered with SQL Server provider using connection string "Database"
