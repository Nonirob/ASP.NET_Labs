using Lab11.Filters;

namespace Lab11
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
            services.AddControllersWithViews();
            var logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs.txt");

            services.AddScoped<LoggerFilter>(provider => new LoggerFilter(logFilePath));
            
            services.AddScoped<UserFilter>(provider => new UserFilter(logFilePath));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
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
                endpoints.MapControllerRoute(
                    name: "main",
                    pattern: "{controller=Index}/{action=Index}/{id?}");
            });
        }
    }
}