namespace mark.davison.engine.common;

public struct Rect<T> where T : struct
{
    public Rect()
    {

    }

    public Rect(T x, T y, T width, T height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public T X { get; set; }
    public T Y { get; set; }
    public T Width { get; set; }
    public T Height { get; set; }
}
