﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShoppingOnLine.Pricing.Api.Event;
using ShoppingOnLine.EventBus.Abstraction;
using ShoppingOnLine.ShoppingCart.Api.Event;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ShoppingOnLine.ShoppingCart.Api
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
            services
                .AddRabbitMQServiceBus("localhost")
                .AddInMemorySubscriptionManager();

            services.AddTransient<IIntegrationEventHandler<PricingOnPriceChange>, ShoppingCartChangePriceIntegrationEventHandler >();
            //services.AddSingleton<PricingOnPriceChange>();

            services.AddSingleton<ShoppingCart.Api.Model.Cart>(cart => 
            {
                return new Model.Cart()
                {
                    Items = new List<Model.CartItem>(),
                    CartId = 1,
                    CreateDateTime = DateTime.Now,
                    UserId = 1
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureEventBus(app);

            app.UseMvc();
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PricingOnPriceChange, ShoppingCartChangePriceIntegrationEventHandler>();
        }
    }
}
