using Model = mark.davison.engine.renderer.abstractions.Resources.Model;

namespace mark.davison.engine.renderer.raylib;

public class RaylibImmediateModeRenderer : IImmediateModeRenderer
{
    private readonly ITextureManager<Texture2D> _textureManager;
    private readonly IModelManager<Raylib_cs.Model> _modelManager;

    public RaylibImmediateModeRenderer(
        ITextureManager<Texture2D> textureManager,
        IModelManager<Raylib_cs.Model> modelManager)
    {
        _textureManager = textureManager;
        _modelManager = modelManager;
    }

    public int MeasureText(string text, int fontSize)
    {
        return Raylib.MeasureText(text, fontSize);
    }

    public void RenderText(string text, int x, int y, int fontSize, Colour colour)
    {
        Raylib.DrawText(text, x, y, fontSize, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderLine(Vector2 start, Vector2 end, Colour colour)
    {
        Raylib.DrawLine((int)start.X, (int)start.Y, (int)end.X, (int)end.Y, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderQuad(Rect target, Colour colour)
    {
        Raylib.DrawRectangle((int)target.X, (int)target.Y, (int)target.Width, (int)target.Height, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderQuad(Rect target, Rect texture, string textureName, Colour colour)
    {
        RenderQuad(target, texture, textureName, 0.0f, colour);
    }

    public void RenderQuad(Rect target, Rect texture, string textureName, float rotation, Colour colour)
    {
        RenderQuad(target, texture, textureName, 0.0f, new Vector2(), colour);
    }
    public void RenderQuad(Rect target, Rect texture, string textureName, float rotation, Vector2 origin, Colour colour)
    {
        var tex = _textureManager.GetTextureImplementation(textureName);

        Raylib.DrawTexturePro(
            tex,
            new Rectangle(texture.X, texture.Y, texture.Width, texture.Height),
            new Rectangle(target.X, target.Y, target.Width, target.Height),
            origin,
            rotation,
            new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderCircle(Vector2 center, float radius, Colour colour)
    {
        Raylib.DrawCircle((int)center.X, (int)center.Y, radius, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderCircleOutline(Vector2 center, float radius, Colour colour)
    {
        Raylib.DrawCircleLines((int)center.X, (int)center.Y, radius, new Color(colour.r, colour.g, colour.b, colour.a));
    }

    public void RenderModel(Model model, Vector3 center)
    {
        var mod = _modelManager.GetModelImplementation(model.Name);

        Raylib.DrawModelWires(mod, center, 1.0f, Color.White);
    }

    public void Begin3D()
    {
        Camera3D camera = new Camera3D
        {
            FovY = 45.0f,
            Target = new Vector3(0.0f, 0.0f, 0.0f),
            Projection = CameraProjection.Perspective,
            Position = new Vector3(0.0f, 4.0f, -10.0f),
            Up = new Vector3(0.0f, 1.0f, 0.0f)
        };
        //Raylib.UpdateCamera(ref camera, CameraMode.CAMERA_ORBITAL);
        Raylib.BeginMode3D(camera);
    }

    public void End3D()
    {
        Raylib.EndMode3D();
    }
}
