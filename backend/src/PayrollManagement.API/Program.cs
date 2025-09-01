using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PayrollManagement.Infrastructure.Data;
using PayrollManagement.Infrastructure.Repositories;
using PayrollManagement.Infrastructure.Services;
using PayrollManagement.Core.Interfaces;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// configuration
var configuration = builder.Configuration;

// Add services
builder.Services.AddControllers();

// EF Core - SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

// Unit of Work & Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Authentication - JWT
var jwtKey = configuration["Jwt:Key"];
var issuer = configuration["Jwt:Issuer"];
var audience = configuration["Jwt:Audience"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("JWT Key not configured in appsettings.");
}

var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30)
    };
});

// Swagger and JWT support in Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PayrollManagement API", Version = "v1" });
    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Enter 'Bearer {token}'"
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    });
});

// Add services
builder.Services.AddControllers();

// --- CORS setup ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // your React dev URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add other services like DB, JWT, etc.

var app = builder.Build();

// Create DB & run migrations at startup (simple approach)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var passwordService = scope.ServiceProvider.GetRequiredService<IPasswordService>();
    db.Database.Migrate();
    SeedData.EnsureSeedData(db, passwordService);
}


// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
