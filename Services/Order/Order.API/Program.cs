
using BuildingBlocks.Domain.Event;
using BuildingBlocks.MassTransit;
using BuildingBlocks.Mediator;
using MagicOnion;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Order.API.Configuration;
using Order.Application;
using Order.Domain.Repository;
using Order.Infrastructure.Repository;

namespace Order.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = builder.Configuration;
            //builder.Services.AddCustomMediator();
            builder.Services.ApplicationService();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            
            builder.Services.Configure<GrpcOptions>(options => configuration.GetSection("Grpc").Bind(options));
            builder.Services.AddMassTransit(config =>
            {
                //Mark this as consumer
                //config.AddConsumer<>();
                //config.AddConsumer<BasketOrderingConsumerV2>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                    //provide the queue name with consumer settings
                    //cfg.ReceiveEndpoint(EventBusConstants.OrderQueue, c =>
                    //{
                    //    c.ConfigureConsumer<BasketOrderingConsumer>(ctx);
                    //});
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
