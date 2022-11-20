using Microsoft.EntityFrameworkCore;
using UTMShmotki.Application;
using UTMShmotki.Application.Interfaces.Repositories;
using UTMShmotki.Infrastructure.Contexts;
using UTMShmotki.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "UTMShmotkiPolicy",
        policy =>
        {
            policy
                .WithOrigins(new[] { "http://localhost:3000", "http://localhost:4200" })
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
     b => b.MigrationsAssembly("UTMShmotki.Infrastructure")));

builder.Services.AddScoped<IRepository, EFCoreRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddApplicationLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("UTMShmotkiPolicy");

app.Run();