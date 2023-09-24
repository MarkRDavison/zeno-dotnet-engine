namespace mark.davison.engine.game.Infrastructure;

public abstract class Application : IApplication
{
    private bool _running;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IOptions<ApplicationConfiguration> _applicationConfigurationOptions;
    private readonly IServiceProvider _serviceProvider;

    private IScene? _currentScene;

    public Application(
        IHostApplicationLifetime hostApplicationLifetime,
        IOptions<ApplicationConfiguration> applicationConfigurationOptions,
        IServiceProvider serviceProvider
    )
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _applicationConfigurationOptions = applicationConfigurationOptions;
        _serviceProvider = serviceProvider;
    }

    public abstract void Initialise(string title);
    public abstract void Teardown();
    public abstract bool ShouldWindowClose();
    public abstract float GetFrameTime();

    public abstract void BeginRender();
    public abstract void EndRender();

    public void SetScene(IScene scene)
    {
        _currentScene = scene;
    }

    public void Start()
    {
        Initialise(_applicationConfigurationOptions.Value.TITLE);

        var sts = _serviceProvider.GetRequiredService<ISceneTransitionService>();
        sts.SetScene(_applicationConfigurationOptions.Value.START_SCENE);

        _running = true;

        while (_running)
        {
            if (ShouldWindowClose())
            {
                _running = false;
            }

            Update(GetFrameTime());

            BeginRender();
            Render();
            EndRender();
        }

        Teardown();
        Stop();
    }

    private void Update(float delta)
    {
        if (_currentScene != null)
        {
            _currentScene.Update(delta);
        }
    }

    private void Render()
    {
        if (_currentScene != null)
        {
            _currentScene.Render();
        }
    }

    public void Stop()
    {
        _hostApplicationLifetime.StopApplication();
    }
}
