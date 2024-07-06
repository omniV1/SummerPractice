using AircraftMaintenanceAPI.Data;
using AircraftMaintenanceAPI.Middleware;
using AircraftMaintenanceAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AircraftMaintenanceAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AircraftMaintenanceContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21))));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAircraftService, AircraftService>();
            services.AddScoped<IMaintenanceRecordService, MaintenanceRecordService>();
            services.AddScoped<IPerformanceMetricService, PerformanceMetricService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
