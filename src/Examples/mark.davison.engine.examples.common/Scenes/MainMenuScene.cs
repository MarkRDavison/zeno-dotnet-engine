namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.MainMenu)]
public class MainMenuScene : IScene
{
    private readonly IImmediateModeRenderer _immediateModeRenderer;
    private readonly IRendererInstance _rendererInstance;
    private readonly IInputManager _inputManager;
    private readonly IInputActionManager _inputActionManager;

    private Vector2 _lastMouse;

    public MainMenuScene(
        IImmediateModeRenderer immediateModeRenderer,
        IRendererInstance rendererInstance,
        IInputManager inputManager,
        IInputActionManager inputActionManager
    )
    {
        _immediateModeRenderer = immediateModeRenderer;
        _rendererInstance = rendererInstance;
        _inputManager = inputManager;
        _inputActionManager = inputActionManager;
    }

    public void Update(float delta)
    {
        _lastMouse = _inputManager.GetMousePosition();
    }

    public void Render()
    {
        var buttonSize = new Vector2(320.0f, 64.0f);
        var size = _rendererInstance.GetWindowSize();

        _immediateModeRenderer.RenderText("Main scene", 8, 8, 32, Colour.DARKGRAY);

        var startingLocationCenter = new Vector2(size.X / 2.0f, 200.0f);

        Colour buttonColour = Colour.LIGHTGRAY;

        if (startingLocationCenter.X - buttonSize.X / 2.0f < _lastMouse.X &&
            startingLocationCenter.X + buttonSize.X / 2.0f > _lastMouse.X &&
            startingLocationCenter.Y - buttonSize.Y / 2.0f < _lastMouse.Y &&
            startingLocationCenter.Y + buttonSize.Y / 2.0f > _lastMouse.Y)
        {
            buttonColour = Colour.YELLOW;
        }

        _immediateModeRenderer.RenderQuad(new Rect<float>(startingLocationCenter.X - buttonSize.X / 2.0f, startingLocationCenter.Y - buttonSize.Y / 2.0f, buttonSize.X, buttonSize.Y), buttonColour);
    }
}
