namespace mark.davison.engine.renderer.abstractions;

public interface IImmediateModeRenderer
{
    void RenderText(string text, int x, int y, int fontSize, Colour colour);
    void RenderQuad(Rect<float> target, Colour colour);
}
