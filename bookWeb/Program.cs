global using FastEndpoints;
global using FluentValidation;
using bookWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Public.GetBooks;
using bookWebApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using Serilog;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["Jwt:secret"]);
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWebDB"));
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

builder.Services.AddResponseCaching();

if (builder.Environment.IsDevelopment())
{
    builder.Host.UseSerilog((context, config) =>
        config.WriteTo.Console(Serilog.Events.LogEventLevel.Verbose));
}
else
{
    builder.Host.UseSerilog((context, config) =>
        config.WriteTo.File("Logs\\log-.txt", Serilog.Events.LogEventLevel.Warning, rollingInterval: RollingInterval.Day));
}

var app = builder.Build();
app.UseResponseCaching();


app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints()
    .UseSwaggerGen();
app.UseCors("AllowAllOrigins");


app.Run();