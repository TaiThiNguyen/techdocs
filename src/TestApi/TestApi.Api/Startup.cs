using Api.Config;

public static class Startup
{
    public static IServiceCollection AddOpenTelemetry(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, ElvidConfig elvidConfig)
    {
        return services;
    }
}

