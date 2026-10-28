using Microsoft.EntityFrameworkCore;
using ParqueoApi.Data;
using ParqueoApi.Repositories;
using ParqueoApi.Repositories.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Parqueo")
    ?? throw new InvalidOperationException("Falta configurar ConnectionStrings:Parqueo.");
builder.Services.AddDbContext<ParqueoDbContext>(options => options.UseSqlite(connectionString));

var fuenteDatos = builder.Configuration["FuenteDatos"]?.Trim()
    ?? throw new InvalidOperationException("Falta configurar FuenteDatos como 'BaseDatos' o 'Json'.");
switch (fuenteDatos)
{
    case "BaseDatos":
        builder.Services.AddScoped<IAutomovilRepository, AutomovilRepository>();
        builder.Services.AddScoped<IParqueoRepository, ParqueoRepository>();
        builder.Services.AddScoped<IIngresoRepository, IngresoRepository>();
        break;
    case "Json":
        builder.Services.AddScoped<IAutomovilRepository>(services =>
            new AutomovilJsonRepository(services.GetRequiredService<IHostEnvironment>().ContentRootPath));
        builder.Services.AddScoped<IParqueoRepository>(services =>
            new ParqueoJsonRepository(services.GetRequiredService<IHostEnvironment>().ContentRootPath));
        builder.Services.AddScoped<IIngresoRepository>(services =>
            new IngresoJsonRepository(services.GetRequiredService<IHostEnvironment>().ContentRootPath));
        break;
    default:
        throw new InvalidOperationException($"FuenteDatos '{fuenteDatos}' no válida. Use 'BaseDatos' o 'Json'.");
}

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
