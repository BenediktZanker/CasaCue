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
    options.UseNpgsql(dbConnectionString, b => 
        b.MigrationsAssembly("CasaCue"))); // Stellt sicher, dass Migrationen aus dem richtigen Projekt kommen

builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Business-Logik
builder.Services.AddScoped<WaitlistService>();

var app = builder.Build();

// ---- Automatische Migration ausführen ----
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate(); // Führt ausstehende Migrationen aus
        Log.Information("Datenbankmigration erfolgreich ausgeführt.");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Fehler bei der Datenbankmigration. Überprüfen Sie die Verbindung oder die Migrationen.");
    }
}

// ---- Middleware ----
// Swagger nur in Development-Umgebungen aktivieren
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

// Für Integrationstests
public partial class BackendProgram { }
