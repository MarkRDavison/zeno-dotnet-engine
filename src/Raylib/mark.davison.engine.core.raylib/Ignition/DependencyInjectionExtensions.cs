namespace mark.davison.engine.core.raylib.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection UseRaylibBackend(this IServiceCollection services)
    {
        services
            .UseRaylibRenderer()
            .UseRaylibInput();
        return services;
    }
}
