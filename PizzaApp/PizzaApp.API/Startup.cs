using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Implementations;
using PizzaApp.Domain.Repositories.Interfaces;
using PizzaApp.Services.Mappings;
using PizzaApp.Services.Servicess.Implementations;
using PizzaApp.Services.Servicess.Interfaces;

namespace PizzaApp.API
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
            services.AddControllers();

            services.AddDbContext<PizzaAppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IOrderRepositroy, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IStateRepositroy, StateRepositroy>();
            services.AddTransient<IStateService, StateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
