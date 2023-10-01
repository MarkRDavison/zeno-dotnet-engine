namespace mark.davison.engine.game.Services;

public class SceneTransitionService : ISceneTransitionService
{
    private readonly IApplication _application;
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, Type> _sceneRegistrations = new();

    public SceneTransitionService(
        IApplication application,
        IServiceProvider serviceProvider
    )
    {
        _application = application;
        _serviceProvider = serviceProvider;
    }

    public void SetScene(string name)
    {
        if (_sceneRegistrations.TryGetValue(name, out var sceneType))
        {
            var typedScene = _serviceProvider.GetService(sceneType);
            if (typedScene is IScene scene)
            {
                scene.Init();
                _application.SetScene(scene);
            }
        }
        else
        {
            Console.Error.WriteLine("Scene {0} was not registered.", name);
        }
    }

    public void RegisterScene<TScene>(string name) where TScene : class, IScene
    {
        RegisterScene(name, typeof(TScene));
    }

    public void RegisterScene(string name, Type sceneType)
    {
        _sceneRegistrations[name] = sceneType;
    }
}
