using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UTMShmotki.Application;
using UTMShmotki.Application.Interfaces;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Infrastructure.Contexts;
using UTMShmotki.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("UTMShmotki.Infrastructure")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();