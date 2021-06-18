using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TeamWebshopProject.API.CSRD.Repository.Classes;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Classes;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Database;
using TeamWebshopProject.API.Database.Context;

namespace TeamWebshopProject.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS configuration needed in order to allow angular app to communicate with server
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddDbContext<TeamWebshopDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString"))
                );

            //DI - repositories
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICreditRepository, CreditRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITagRepository, TagRepository>();


            //DI - Services
            services.AddScoped<IBasketItemService, BasketItemService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICreditService, CreditService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITagService, TagService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TeamWebshopProject.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeamWebshopProject.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
