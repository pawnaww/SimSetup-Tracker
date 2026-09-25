using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using SimSetup.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja kontrolerów API
builder.Services.AddControllers();

// Konfiguracja bazy danych SQLite z Entity Framework Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracja Swagger / OpenAPI dla dokumentacji żądań HTTP
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SimSetup Tracker API",
        Version = "v1",
        Description = "Web API dla graczy simracingowych do zarządzania setupami samochodów i analizy czasów okrążeń."
    });
});

var app = builder.Build();

// Konfiguracja potoku HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SimSetup Tracker API v1");
        options.RoutePrefix = string.Empty; // Swagger dostępny bezpośrednio pod adresem głównym (root)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
