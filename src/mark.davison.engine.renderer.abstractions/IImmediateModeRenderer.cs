namespace mark.davison.engine.renderer.abstractions;

public interface IImmediateModeRenderer
{
    int MeasureText(string text, int fontSize);
    void RenderText(string text, int x, int y, int fontSize, Colour colour);
    void RenderQuad(Rect target, Colour colour);
    void RenderQuad(Rect target, Rect texture, string textureName, Colour colour);
}
