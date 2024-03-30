namespace mark.davison.engine.renderer.raylib.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection UseRaylibRenderer(this IServiceCollection services)
    {
        services
            .AddSingleton<IImmediateModeRenderer, RaylibImmediateModeRenderer>()
            .AddSingleton<IRendererInstance, RaylibRendererInstance>()
            .AddSingleton<ITextureManager<Texture2D>, RaylibTextureManager>()
            .AddSingleton<IModelManager<Raylib_cs.Model>, RaylibModelManager>()
            .AddSingleton<ISoundManager, RaylibSoundManager>()
            .AddSingleton<ITextureManager>(_ => _.GetRequiredService<ITextureManager<Texture2D>>())
            .AddSingleton<IModelManager>(_ => _.GetRequiredService<IModelManager<Raylib_cs.Model>>());

        return services;
    }
}
