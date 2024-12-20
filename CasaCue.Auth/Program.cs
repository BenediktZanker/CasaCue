using CasaCue.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---- Logging-Konfiguration ----
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/auth-log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
    .CreateLogger();
builder.Host.UseSerilog();

// ---- Konfigurationen laden ----
builder.Configuration.AddEnvironmentVariables(prefix: "JWT_"); // Umgebungsvariablen laden
var jwtSecret = builder.Configuration["Jwt:Secret"] ?? "fallback_secret_key";

if (jwtSecret == "fallback_secret_key")
{
    Log.Warning("JWT Secret wurde nicht aus Umgebungsvariablen geladen. Der Fallback-Secret-Key wird verwendet.");
}

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(dbConnectionString))
{
    Log.Error("Datenbankverbindung ist nicht gesetzt. Überprüfen Sie die Konfiguration oder Umgebungsvariablen.");
}

// ---- Services hinzufügen ----
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dbConnectionString, b =>
        b.MigrationsAssembly("CasaCue.Auth"))); // Auth-Service-Migrationen

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

builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Swagger hinzufügen
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// ---- Middleware ----
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // Aktiviert Swagger
    app.UseSwaggerUI();       // Aktiviert Swagger-UI
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Für Integrationstests
public partial class AuthProgram { }

