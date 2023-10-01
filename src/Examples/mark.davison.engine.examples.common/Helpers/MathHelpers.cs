namespace mark.davison.engine.examples.common.Helpers;

public static class MathHelpers
{
    public static Vector2 ToDirection(this float rotation)
    {
        var (sin, cos) = Math.SinCos(rotation * (float)Math.PI / 180.0f);
        return new((float)sin, (float)-cos);
    }
}
