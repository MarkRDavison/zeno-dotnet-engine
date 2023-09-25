namespace mark.davison.engine.input.raylib.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection UseRaylibInput(this IServiceCollection services)
    {
        services
            .AddSingleton<IInputManager, RaylibInputManager>();

        return services;
    }
}
