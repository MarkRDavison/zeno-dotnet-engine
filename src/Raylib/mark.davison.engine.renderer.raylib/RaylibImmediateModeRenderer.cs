namespace mark.davison.engine.renderer.raylib;

public class RaylibImmediateModeRenderer : IImmediateModeRenderer
{
    public void RenderText(string text, int x, int y, int fontSize, Colour colour)
    {
        Raylib.DrawText(text, x, y, fontSize, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderQuad(Rect<float> target, Colour colour)
    {
        Raylib.DrawRectangle((int)target.X, (int)target.Y, (int)target.Width, (int)target.Height, new Color(colour.r, colour.g, colour.b, colour.a));
    }
}
