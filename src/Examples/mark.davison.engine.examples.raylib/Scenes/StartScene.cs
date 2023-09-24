using mark.davison.engine.core.abstractions.Services;

namespace mark.davison.engine.examples.raylib.Scenes;

[SceneRegistration(Name = Scenes.Start)]
public class StartScene : IScene
{
    private float _elapsed = 0.0f;
    private readonly ISceneTransitionService _sceneTransitionService;

    public StartScene(ISceneTransitionService sceneTransitionService)
    {
        _sceneTransitionService = sceneTransitionService;
    }

    public void Update(float delta)
    {
        _elapsed += delta;

        if (_elapsed > 5.0f)
        {
            _sceneTransitionService.SetScene(Scenes.MainMenu);
        }
    }

    public void Render()
    {

    }
}
