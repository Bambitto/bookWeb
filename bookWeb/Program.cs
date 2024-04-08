global using FastEndpoints;
global using FluentValidation;
using FastEndpoints.Swagger;
using bookWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Public.GetBooks;
using bookWebApi.Repository;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints()
    .AddSwaggerDocument();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookWebDB"));
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();

var app = builder.Build();
app.UseFastEndpoints()
    .UseSwaggerGen();

app.UseResponseCaching();

app.Run();