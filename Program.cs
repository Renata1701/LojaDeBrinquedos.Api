using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using LojaDeBrinquedos.Domain.Interfaces;
using LojaDeBrinquedos.API.Services;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("MinhaConexaoSQL");
Console.WriteLine($"Connection String lida: {connStr}");

// Add services to the container.
builder.Services.AddControllers();

// Registrar serviços
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger();
    app.MapControllers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

