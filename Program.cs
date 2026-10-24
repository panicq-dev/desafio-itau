using System.Text.Json;
using DesafioItau.Aplicacao.Servicos.Estatisticas;
using DesafioItau.Aplicacao.Servicos.Transacoes;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddSingleton<ITransacaoService, TransacaoService>();
builder.Services.AddSingleton<IEstatisticasService, EstatisticasService>();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();