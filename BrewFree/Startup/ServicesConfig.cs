using BrewFree.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BrewFree
{
    public static class ServicesConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IBrewerService, BrewerService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
