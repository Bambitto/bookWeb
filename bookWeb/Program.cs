global using FastEndpoints;
global using FluentValidation;
using FastEndpoints.Swagger;
using bookWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Public.GetBooks;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints()
    .AddSwaggerDocument();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWebDB"));
});
builder.Services.AddScoped<Data>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseFastEndpoints()
    .UseSwaggerGen();
app.Run();