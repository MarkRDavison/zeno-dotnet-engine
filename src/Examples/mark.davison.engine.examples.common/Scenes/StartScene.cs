namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.Start)]
public class StartScene : IScene
{
    private const float TransitionTime = 2.0f;
    private float _elapsed = 0.0f;
    private readonly ISceneTransitionService _sceneTransitionService;
    private readonly IImmediateModeRenderer _immediateModeRenderer;

    public StartScene(
        ISceneTransitionService sceneTransitionService,
        IImmediateModeRenderer immediateModeRenderer
    )
    {
        _sceneTransitionService = sceneTransitionService;
        _immediateModeRenderer = immediateModeRenderer;
    }

    public void Update(float delta)
    {
        _elapsed += delta;

        if (_elapsed > TransitionTime)
        {
            _sceneTransitionService.SetScene(Scenes.MainMenu);
        }
    }

    public void Render()
    {
        _immediateModeRenderer.RenderText("Raylib example", 8, 8, 32, Colour.DARKGRAY);
        _immediateModeRenderer.RenderText($"Scene change in {TransitionTime - _elapsed:N2}s", 8, 42, 32, Colour.DARKGRAY);
    }
}
