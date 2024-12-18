using CasaCue.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using CasaCue.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---- Logging-Konfiguration ----
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
    .CreateLogger();
builder.Host.UseSerilog();

// ---- Konfigurationen laden ----
var jwtSecret = builder.Configuration["Jwt:Secret"] ?? "fallback_secret_key";
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ---- Services hinzufügen ----
// Datenbankkontext mit PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dbConnectionString)
           .LogTo(Console.WriteLine, LogLevel.Information));

// Authentifizierungsservice (JWT)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "CasaCueAPI",
            ValidAudience = "CasaCueClients",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Business-Logik
builder.Services.AddScoped<WaitlistService>();

var app = builder.Build();

// ---- Umgebungsabhängiges Logging ----
if (app.Environment.IsEnvironment("Test"))
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("logs/test-log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
}

// ---- Middleware ----
// Swagger nur in Development-Umgebungen aktivieren
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // CORS aktivieren
app.UseAuthentication(); // JWT-Authentifizierung
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Starting CasaCue Application...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

// Für Integrationstests
public partial class Program { }

