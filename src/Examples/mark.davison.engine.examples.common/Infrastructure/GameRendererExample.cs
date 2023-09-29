namespace mark.davison.engine.examples.common.Infrastructure;

public class GameRendererExample : IGameRenderer
{
    private readonly ISpritesheetManager _spritesheetManager;
    private readonly ITextureManager _textureManager;
    private readonly IImmediateModeRenderer _immediateModeRenderer;

    public GameRendererExample(
        ISpritesheetManager spritesheetManager,
        ITextureManager textureManager,
        IImmediateModeRenderer immediateModeRenderer
    )
    {
        _spritesheetManager = spritesheetManager;
        _textureManager = textureManager;
        _immediateModeRenderer = immediateModeRenderer;
    }

    public void Update(float delta)
    {

    }

    public void Render()
    {
        var spriteBounds = _spritesheetManager.GetSpriteBounds("spritesheet", "test");

        _immediateModeRenderer.RenderQuad(
            new Rect(128.0f, 128.0f, 256.0f, 256.0f),
            spriteBounds,
            "spritesheet",
            Colour.WHITE);
    }
}
