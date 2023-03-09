using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models.Repositories.Implement;
using ProductCatalog.Models.Repositories.Interfaces;
using ProductCatalog.Models.Validators;
using ProductCatalog.Seeders;

namespace ProductCatalog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Fluent validation
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        builder.Services.AddControllers(options => {
            // Custom model validation error message
            options.Filters.Add(typeof(ValidateModelStateAttribute));
        })
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        builder.Services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")
        ));

        // DI 註冊
        builder.Services.AddScoped<IProductItemRepository, ProductItemRepository>();
        builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

        var app = builder.Build();

        // Seeder
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<ApplicationDbContext>();
            DataSeeder seeder = new DataSeeder(context);
            seeder.SeedProductsAndProductCatalogTypes();
        }

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
