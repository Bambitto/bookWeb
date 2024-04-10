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

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["Jwt:secret"]);
builder.Services.AddAuthorization();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWebDB"));
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();


builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints()
    .UseSwaggerGen();

app.UseResponseCaching();

app.Run();