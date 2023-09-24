namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.MainMenu)]
public class MainMenuScene : IScene
{
    private bool _outputted;
    private readonly ILogger _logger;

    public MainMenuScene(
        ILogger<MainMenuScene> logger
    )
    {
        _logger = logger;
    }

    public void Update(float delta)
    {
        if (!_outputted)
        {
            _outputted = true;
            _logger.LogInformation("MAIN MENU");
        }
    }

    public void Render()
    {

    }
}
