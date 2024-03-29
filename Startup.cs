using logistics_management_backend.Infrastructure;
using logistics_management_backend.Domain.Shared;
using logistics_management_backend.Infrastructure.Products;
using logistics_management_backend.Infrastructure.Requests;
using logistics_management_backend.Services.Products;
using logistics_management_backend.Services.Requests;
using Microsoft.EntityFrameworkCore;

namespace logistics_management_backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddCors(options => options.AddPolicy("Cors",
                builder =>
                {
                    builder.
                        AllowAnyOrigin().
                        AllowAnyMethod().
                        AllowAnyHeader();
                }));
            
            
            services.AddDbContext<DbContextLM>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("localdatabase")).LogTo(Console.WriteLine,LogLevel.Information));
            ConfigureMyServices(services);

            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();

        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseHttpsRedirection();
        

            app.UseRouting();
            app.UseCors("Cors");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddHttpClient();
            
            
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IProductService, ProductService>();           
            
            services.AddTransient<IRequestService,RequestService>();
            services.AddTransient<IRequestRepository, RequestRepository>();


        }




    }
}