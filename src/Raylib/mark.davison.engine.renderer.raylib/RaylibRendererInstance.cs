namespace mark.davison.engine.renderer.raylib;

internal class RaylibRendererInstance : IRendererInstance
{
    public Vector2 GetWindowSize()
    {
        return new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
    }
}
