
using BuildingBlocks.Domain.Event;
using MassTransit;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using Product.Application;
using Product.Application.Comsumers;
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
            var configuration = builder.Configuration;
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
            builder.Services.AddScoped<IVariantProductRepository, VariantProductRepository>();
            builder.Services.AddScoped<OrderConsumer>();
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMagicOnion();
            builder.Services.AddMassTransit(config =>
            {
                //Mark this as consumer
                //config.AddConsumer<>();
                config.AddConsumer<OrderConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    //provide the queue name with consumer settings
                    cfg.ReceiveEndpoint(EventBusConstants.OrderQueue, c =>
                    {
                        c.ConfigureConsumer<OrderConsumer>(ctx);
                    });
                    ////V2 endpoint will pick items from here 
                    //cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueueV2, c =>
                    //{
                    //    c.ConfigureConsumer<BasketOrderingConsumerV2>(ctx);
                    //});
                });
            });


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
