using logistics_management_backend.Infrastructure;
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
            services.AddDbContext<DbContextLM>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("localdatabase")).LogTo(Console.WriteLine,LogLevel.Information));

        
        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
        public void ConfigureMyServices(IServiceCollection services)
        {


        }




    }
}