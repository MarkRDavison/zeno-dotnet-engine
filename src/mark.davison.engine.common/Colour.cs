namespace mark.davison.engine.common;

public partial struct Colour
{
    public byte r;
    public byte g;
    public byte b;
    public byte a;

    public static readonly Colour LIGHTGRAY = new Colour(200, 200, 200, 255);
    public static readonly Colour GRAY = new Colour(130, 130, 130, 255);
    public static readonly Colour DARKGRAY = new Colour(80, 80, 80, 255);
    public static readonly Colour YELLOW = new Colour(253, 249, 0, 255);
    public static readonly Colour GOLD = new Colour(255, 203, 0, 255);
    public static readonly Colour ORANGE = new Colour(255, 161, 0, 255);
    public static readonly Colour PINK = new Colour(255, 109, 194, 255);
    public static readonly Colour RED = new Colour(230, 41, 55, 255);
    public static readonly Colour MAROON = new Colour(190, 33, 55, 255);
    public static readonly Colour GREEN = new Colour(0, 228, 48, 255);
    public static readonly Colour LIME = new Colour(0, 158, 47, 255);
    public static readonly Colour DARKGREEN = new Colour(0, 117, 44, 255);
    public static readonly Colour SKYBLUE = new Colour(102, 191, 255, 255);
    public static readonly Colour BLUE = new Colour(0, 121, 241, 255);
    public static readonly Colour DARKBLUE = new Colour(0, 82, 172, 255);
    public static readonly Colour PURPLE = new Colour(200, 122, 255, 255);
    public static readonly Colour VIOLET = new Colour(135, 60, 190, 255);
    public static readonly Colour DARKPURPLE = new Colour(112, 31, 126, 255);
    public static readonly Colour BEIGE = new Colour(211, 176, 131, 255);
    public static readonly Colour BROWN = new Colour(127, 106, 79, 255);
    public static readonly Colour DARKBROWN = new Colour(76, 63, 47, 255);
    public static readonly Colour WHITE = new Colour(255, 255, 255, 255);
    public static readonly Colour BLACK = new Colour(0, 0, 0, 255);
    public static readonly Colour BLANK = new Colour(0, 0, 0, 0);
    public static readonly Colour MAGENTA = new Colour(255, 0, 255, 255);
    public static readonly Colour RAYWHITE = new Colour(245, 245, 245, 255);

    public Colour(byte r, byte g, byte b, byte a)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }

    public Colour(int r, int g, int b, int a)
    {
        this.r = Convert.ToByte(r);
        this.g = Convert.ToByte(g);
        this.b = Convert.ToByte(b);
        this.a = Convert.ToByte(a);
    }

    public override string ToString()
    {
        return $"{{R:{r} G:{g} B:{b} A:{a}}}";
    }
}
