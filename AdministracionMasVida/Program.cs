﻿


using AdministracionMasVida.Services;
using AdministracionMasVida.Services.Interfaces;
using AdministracionMasVidaDbContext.DbContexts;
using AdministracionMasVidaDbContext.Services;
using AdministracionMasVidaDbContext.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var constr = "server=localhost;database=InitialDataBase;uid=root;pwd=pwd123;port=3306;";

builder.Services
    .AddDbContext<AdministracionMasVidaDbcontext>(options =>
        options.UseMySql(constr, ServerVersion.AutoDetect(constr)));

builder.Services.AddScoped<IServidorService, ServidorService>();
builder.Services.AddScoped<ILugaresMvService, lugaresMvService>();
builder.Services.AddScoped<IGrupoPequenoService, GrupoPequenoService>();
builder.Services.AddScoped<IEventosMvService, EventosMvService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

