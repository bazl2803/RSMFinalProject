using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistence;
using WebApi.Endpoints;
using WebApi.OptionsSetup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddPersistence(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapSaleEndpoints();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.Run();