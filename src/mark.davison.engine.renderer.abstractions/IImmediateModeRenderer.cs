namespace mark.davison.engine.renderer.abstractions;

public interface IImmediateModeRenderer
{
    int MeasureText(string text, int fontSize);
    void RenderText(string text, int x, int y, int fontSize, Colour colour);
    void RenderLine(Vector2 start, Vector2 end, Colour colour);
    void RenderQuad(Rect target, Colour colour);
    void RenderQuad(Rect target, Rect texture, string textureName, Colour colour);
    void RenderQuad(Rect target, Rect texture, string textureName, float rotation, Colour colour);
    void RenderQuad(Rect target, Rect texture, string textureName, float rotation, Vector2 origin, Colour colour);
    void RenderCircle(Vector2 center, float radius, Colour colour);
    void RenderCircleOutline(Vector2 center, float radius, Colour colour);
}
