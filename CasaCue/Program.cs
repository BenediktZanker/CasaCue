using CasaCue.Services;
using CasaCue.Shared.Data; // Gemeinsame Datenbankkontext-Klasse
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ---- Logging-Konfiguration ----
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/backend-log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
    .CreateLogger();
builder.Host.UseSerilog();

// ---- Konfigurationen laden ----
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ---- Services hinzufügen ----
// Datenbankkontext mit PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dbConnectionString)
        .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Business-Logik
builder.Services.AddScoped<WaitlistService>();

var app = builder.Build();

// ---- Middleware ----
// Swagger nur in Development-Umgebungen aktivieren
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Starting CasaCue Backend Service...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Backend Service terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

// Für Integrationstests
public partial class BackendProgram { }