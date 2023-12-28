
using TechChallengeFiap.Application.Interfaces;
using TechChallengeFiap.Application.Services;
using TechChallengeFiap.Domain.Interfaces;
using TechChallengeFiap.Infra.Data;
using TechChallengeFiap.Infra.Data.Context;
using TechChallengeFiap.Infra.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ProdutosConection");

builder.Services.AddDbContext<ConsultaAcoesDBContext>(
    o => o.UseSqlServer(connectionString)
    );
builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiExternaFinanceIntegration, ApiExternaFinanceIntegration>();
builder.Services.AddScoped<ICotacoesAcoesService, CotacoesAcoesService>();
//builder.Services.AddDbContext<JobsDbContext>(
//    o => o.UseInMemoryDatabase("JobsDb")
//    );

// Configurar o AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
