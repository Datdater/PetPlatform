
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using Product.Application;
using Product.Domain.Repository;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repository;
using System.Reflection;

namespace Product.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // services.AddCors(options =>
            // {
            //     options.AddPolicy("CorsPolicy", policy =>
            //     {
            //         policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            //     });
            // });
            
            // Add services to the container.
            
            //DI
            builder.Services.ApplicationService();
            builder.Services.AddGrpc();
            // Add this line to register ProductContext and IMongoDatabase in the DI container
            builder.Services.AddSingleton<ProductContext>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMagicOnion();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMagicOnionService();
            });

            app.Run();
        }
    }
}
