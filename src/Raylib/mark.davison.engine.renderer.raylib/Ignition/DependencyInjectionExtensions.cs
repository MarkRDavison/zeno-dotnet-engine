namespace mark.davison.engine.renderer.raylib.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection UseRaylibRenderer(this IServiceCollection services)
    {
        services
            .AddSingleton<IImmediateModeRenderer, RaylibImmediateModeRenderer>()
            .AddSingleton<IRendererInstance, RaylibRendererInstance>();

        return services;
    }
}
