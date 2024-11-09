using CP3.Application.Interfaces;
using CP3.Application.Services;
using CP3.Data.AppData;
using CP3.Domain.Interfaces;
using CP3.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registre os serviços
builder.Services.AddScoped<IBarcoService, BarcoService>();
builder.Services.AddScoped<IBarcoRepository, BarcoRepository>();

// Configurar o ApplicationContext com a string de conexão
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
