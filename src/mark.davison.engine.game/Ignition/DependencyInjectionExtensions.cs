namespace mark.davison.engine.game.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection UseGame<TApplication>(this IServiceCollection services, params Type[] types)
        where TApplication : class, IApplication
    {
        services
            .AddSingleton<IApplication, TApplication>()
            .AddSingleton<ISpritesheetManager, SpritesheetManager>()
            .AddSingleton<IInputActionManager, InputActionManager>()
            .RegisterScenes<TApplication>(types)
            .RegisterGame(types);

        return services;
    }

    public static IServiceCollection UseECS(this IServiceCollection services, params Type[] types)
    {
        services.AddTransient<ECSWorld>();

        foreach (var t in types.Concat(new[] { typeof(ECSWorld) }).SelectMany(_ => _.Assembly.GetTypes()))
        {
            if (t.IsAssignableTo(typeof(ISystem)) && t != typeof(ISystem))
            {
                services.AddTransient(t);
            }
        }

        return services;
    }

    private static IServiceCollection RegisterGame(this IServiceCollection services, Type[] types)
    {
        foreach (var t in types.SelectMany(_ => _.Assembly.GetTypes()))
        {
            if (t.IsAssignableTo(typeof(IGame)))
            {
                services.AddSingleton(t);
            }
            if (t.IsAssignableTo(typeof(IGameRenderer)))
            {
                services.AddTransient(t);
            }
        }

        return services;
    }
    private static IServiceCollection RegisterScenes<TApplication>(this IServiceCollection services, Type[] types)
    {
        List<Tuple<string, Type>> sceneTypes = new();

        foreach (var sceneType in types.SelectMany(_ => _.Assembly.GetTypes()))
        {
            if (sceneType.IsAssignableTo(typeof(IScene)))
            {
                var registration = sceneType.GetCustomAttribute<SceneRegistrationAttribute>();

                if (registration == null)
                {
                    Console.WriteLine("Scene {0} does not use the [SceneRegistration] attribute, please add it in order to use it in game.", sceneType.Name);
                    continue;
                }

                sceneTypes.Add(Tuple.Create(registration.Name, sceneType));

                services.AddTransient(sceneType);
            }
        }

        services.AddSingleton<ISceneTransitionService>(_ =>
        {
            var sceneTransitionService = new SceneTransitionService(_.GetRequiredService<IApplication>(), _);

            foreach (var (name, type) in sceneTypes)
            {
                sceneTransitionService.RegisterScene(name, type);
            }

            return sceneTransitionService;
        });

        return services;
    }
}
