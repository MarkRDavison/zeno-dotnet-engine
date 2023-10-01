namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.MainMenu)]
public class MainMenuScene : IScene
{
    private readonly IImmediateModeRenderer _immediateModeRenderer;
    private readonly IRendererInstance _rendererInstance;
    private readonly IInputManager _inputManager;
    private readonly IApplication _application;
    private readonly ISceneTransitionService _sceneTransitionService;

    private Vector2 _lastMouse;
    private Vector2 _lastSize;
    private Vector2 _startingButtonCenter;
    private List<Tuple<string, Rect>> _buttons;
    private readonly List<string> _buttonNames;

    public MainMenuScene(
        IImmediateModeRenderer immediateModeRenderer,
        IRendererInstance rendererInstance,
        IInputManager inputManager,
        IApplication application,
        ISceneTransitionService sceneTransitionService
    )
    {
        _immediateModeRenderer = immediateModeRenderer;
        _rendererInstance = rendererInstance;
        _inputManager = inputManager;
        _application = application;
        _sceneTransitionService = sceneTransitionService;

        _buttons = new();
        _buttonNames = new()
        {
            "Restart",
            "Play",
            "Options",
            "Quit"
        };
    }

    public void Init() { }
    public void Update(float delta)
    {
        _lastMouse = _inputManager.GetMousePosition();
        var size = _rendererInstance.GetWindowSize();

        if (size != _lastSize)
        {
            _lastSize = size;
            var buttonSize = new Vector2(320.0f, 64.0f);
            _startingButtonCenter = new Vector2(size.X / 2.0f, 200.0f);
            _buttons.Clear();

            var currentCenter = _startingButtonCenter;
            foreach (var b in _buttonNames)
            {
                _buttons.Add(Tuple.Create(b, CreateRectFromCenter(currentCenter, buttonSize)));
                currentCenter.Y += buttonSize.Y * 2.0f;
            }
        }

        if (_inputManager.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            foreach (var b in _buttons)
            {
                if (b.Item2.Contains(_lastMouse.X, _lastMouse.Y))
                {
                    HandleClick(b.Item1);
                }
            }
        }
    }

    private void HandleClick(string button)
    {
        switch (button.ToUpper())
        {
            case "RESTART":
                _sceneTransitionService.SetScene(Scenes.Start);
                break;
            case "PLAY":
                _sceneTransitionService.SetScene(Scenes.Game);
                break;
            case "OPTIONS":
                _sceneTransitionService.SetScene(Scenes.Options);
                break;
            case "QUIT":
                _application.Stop();
                break;
        }
    }

    public void Render()
    {
        _immediateModeRenderer.RenderText("Main scene", 8, 8, 32, Colour.DARKGRAY);

        foreach (var b in _buttons)
        {
            var buttonColour = Colour.LIGHTGRAY;
            var textColour = Colour.BLACK;

            if (b.Item2.Contains(_lastMouse.X, _lastMouse.Y))
            {
                buttonColour = Colour.YELLOW;
            }

            _immediateModeRenderer.RenderQuad(b.Item2, buttonColour);

            var textSize = _immediateModeRenderer.MeasureText(b.Item1, 48);
            _immediateModeRenderer.RenderText(
                b.Item1,
                (int)(b.Item2.X + b.Item2.Width / 2.0f - textSize / 2),
                (int)b.Item2.Y + 8,
                48,
                textColour);
        }
    }

    private Rect CreateRectFromCenter(Vector2 center, Vector2 size)
    {
        return new Rect(center.X - size.X / 2.0f, center.Y - size.Y / 2.0f, size.X, size.Y);
    }
}
