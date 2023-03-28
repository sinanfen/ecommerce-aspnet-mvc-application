using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Services.Abstract;
using eTickets.Data.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace eTickets
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
            //dbcontext configuration
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            //AddRazorRuntimeCompilation -->> This package 
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Services configuration
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<ICinemaService, CinemaService>();
            //services.AddScoped<IProducersService, ProducersService>();
            //services.AddScoped<ICinemasService, CinemasService>();
            services.AddScoped<IMoviesService, MoviesService>();
            //services.AddScoped<IOrdersService, OrdersService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            //Authentication and authorization
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            //services.AddMemoryCache();
            //services.AddSession();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseSession();

            //Authentication & Authorization
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
            });

            //Seed database
            AppDbInitializer.Seed(app);
            //AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
        }
    }
}