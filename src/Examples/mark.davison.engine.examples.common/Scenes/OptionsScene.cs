namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.Options)]
public class OptionsScene : IScene
{
    private readonly IImmediateModeRenderer _immediateModeRenderer;

    public OptionsScene(IImmediateModeRenderer immediateModeRenderer)
    {
        _immediateModeRenderer = immediateModeRenderer;
    }

    public void Init() { }
    public void Update(float delta)
    {
    }

    public void Render()
    {
        _immediateModeRenderer.RenderText("Options scene", 8, 8, 32, Colour.DARKGRAY);

    }
}
