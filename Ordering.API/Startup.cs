using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ordering.API.Consumers;
using Sale.API.Entities;
using Sale.API.Persistence;
using Sale.API.Persistence.Repositories;
using System;

namespace Sale.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("InMem"));
            services.AddScoped<IGenericRepository<Buyer>, EFGenericRepository<Buyer>>();
            //services.AddScoped<IGenericRepository<Sale>, EFGenericRepository<Sale>>();

            //services.AddMassTransit(x =>
            //{
            //    x.AddConsumer<SaleConsumer>();
            //    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            //    {
            //        cfg.UseHealthCheck(provider);
            //        cfg.Host(new Uri("rabbitmq://localhost"), h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });
            //        cfg.ReceiveEndpoint("saleQueue", ep =>
            //        {
            //            ep.PrefetchCount = 16;
            //            ep.UseMessageRetry(r => r.Interval(2, 100));
            //            ep.ConfigureConsumer<SaleConsumer>(provider);
            //        });
            //    }));
            //});
            //services.AddMassTransitHostedService();

            services.AddMassTransit(config => {

                config.AddConsumer<SaleConsumer>();

                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host("amqp://guest:guest@localhost:5672");
                    cfg.UseHealthCheck(ctx);

                    cfg.ReceiveEndpoint("salequeue", c => {
                        c.ConfigureConsumer<SaleConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();

            services.AddScoped<SaleConsumer>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
