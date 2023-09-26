namespace mark.davison.engine.renderer.raylib;

public class RaylibImmediateModeRenderer : IImmediateModeRenderer
{
    private readonly ITextureManager<Texture2D> _textureManager;

    public RaylibImmediateModeRenderer(ITextureManager<Texture2D> textureManager)
    {
        _textureManager = textureManager;
    }

    public int MeasureText(string text, int fontSize)
    {
        return Raylib.MeasureText(text, fontSize);
    }

    public void RenderText(string text, int x, int y, int fontSize, Colour colour)
    {
        Raylib.DrawText(text, x, y, fontSize, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderQuad(Rect target, Colour colour)
    {
        Raylib.DrawRectangle((int)target.X, (int)target.Y, (int)target.Width, (int)target.Height, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderQuad(Rect target, Rect texture, string textureName, Colour colour)
    {
        var tex = _textureManager.GetTextureImplementation(textureName);

        Raylib.DrawTexturePro(
            tex,
            new Rectangle(texture.X, texture.Y, texture.Width, texture.Height),
            new Rectangle(target.X, target.Y, target.Width, target.Height),
            new Vector2(),
            0.0f,
            new Color(colour.r, colour.g, colour.b, colour.a));
    }
}
