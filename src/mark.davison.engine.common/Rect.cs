namespace mark.davison.engine.common;

public struct Rect
{
    public Rect()
    {

    }

    public Rect(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public bool Contains(float x, float y)
    {
        return X < x && x < X + Width && Y < y && y < Y + Height;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
}
