using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BrewFree.Data;
using BrewFree.Data.Models;
using BrewFree.Services;

namespace BrewFree
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IBrewerService, BrewerService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext dbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseFacebookAuthentication(new FacebookOptions
            {
                AppId = Configuration["Authentication:Facebook:AppId"],
                AppSecret = Configuration["Authentication:Facebook:AppSecret"]
            });

            app.UseTwitterAuthentication(new TwitterOptions
            {
                ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"],
                ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"]
            });

            app.UseGoogleAuthentication(new GoogleOptions
            {
                ClientId = Configuration["Authentication:Google:ClientId"],
                ClientSecret = Configuration["Authentication:Google:ClientSecret"]
            });

            app.UseMicrosoftAccountAuthentication(new MicrosoftAccountOptions
            {
                ClientId = Configuration["Authentication:Microsoft:ClientId"],
                ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"]
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            MapperConfig.Initialize();

            if (env.IsDevelopment())
            {
                ApplicationDbContextConfig.Initialize(dbContext);
            }
        }
    }
}
