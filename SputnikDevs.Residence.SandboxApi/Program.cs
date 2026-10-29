using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using SputnikDevs.Residence.SandboxApi.Data;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// 1. Controller & JSON Configuration
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialize enums as human-readable strings (e.g. "Plumbing", "Open", "Emergency")
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// 2. Database Provider Configuration (SQLite by default for zero-dependency dev, PostgreSQL optional)
var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider") ?? "Sqlite";

builder.Services.AddDbContext<SandboxDbContext>(options =>
{
    if (databaseProvider.Equals("Sqlite", StringComparison.OrdinalIgnoreCase))
    {
        var sqliteConnection = builder.Configuration.GetConnectionString("SqliteConnection") 
                               ?? "Data Source=residence_sandbox.db";
        options.UseSqlite(sqliteConnection);
    }
    else
    {
        var pgConnection = builder.Configuration.GetConnectionString("PostgresConnection")
                           ?? "Host=localhost;Port=5433;Database=residence_sandbox_db;Username=postgres;Password=postgres";
        options.UseNpgsql(pgConnection);
    }
});

// 3. Swagger / OpenAPI Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sputnik Devs Residence Sandbox API",
        Version = "v1",
        Description = "Decoupled Work-Integrated Learning (WIL) student housing maintenance & issue-tracking API sandbox.",
        Contact = new OpenApiContact
        {
            Name = "Sputnik Devs Engineering Mentorship",
            Email = "mentorship@sputnikdevs.com"
        }
    });
});

// 4. CORS (Allow local frontend/mobile dev)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 5. Database Auto-Migration & Seeding on Startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SandboxDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        logger.LogInformation("Verifying and seeding Sandbox Database ({Provider})...", databaseProvider);
        await DbInitializer.SeedAsync(context);
        logger.LogInformation("Sandbox Database successfully initialized.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error occurred while initializing the sandbox database.");
    }
}

// 6. HTTP Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Residence Sandbox API v1");
    c.RoutePrefix = string.Empty; // Swagger UI at root URL (http://localhost:5000/)
});

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.Run();
