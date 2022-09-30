using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace CompanyEmployees;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        return services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    public static IServiceCollection ConfigureIISConfiguration(this IServiceCollection services)
    {
        return services.Configure<IISOptions>(options => { });
    }

    public static IServiceCollection ConfigureLoggerService(this IServiceCollection services)
    {
        return services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services)
    {
        return services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static IServiceCollection ConfigureServiceManager(this IServiceCollection services)
    {
        return services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static IServiceCollection
        ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<RepositoryContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}