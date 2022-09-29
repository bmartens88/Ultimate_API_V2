using Contracts;
using LoggerService;

namespace CompanyEmployees
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        public static IServiceCollection ConfigureIISConfiguration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        public static IServiceCollection ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
