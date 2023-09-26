namespace mark.davison.engine.renderer.raylib.Managers;

public class RaylibTextureManager : ITextureManager<Texture2D>
{
    private readonly IDictionary<string, Texture2D> _textures;

    public RaylibTextureManager()
    {
        Image isChecked = Raylib.GenImageChecked(64, 64, 8, 8, Color.RED, Color.GREEN);
        Texture2D texture = Raylib.LoadTextureFromImage(isChecked);
        Raylib.UnloadImage(isChecked);
        _textures = new Dictionary<string, Texture2D>
        {
            { "test", texture }
        };
    }

    public Texture GetTexture(string name)
    {
        var texture = GetTextureImplementation(name);

        return new Texture
        {
            Name = name,
            Size = new Vector2(texture.width, texture.height)
        };
    }

    public Texture2D GetTextureImplementation(string name)
    {
        if (_textures.ContainsKey(name))
        {
            return _textures[name];
        }

        return _textures["test"];
    }

    public bool LoadTexture(string name, string path)
    {
        var resolved = Files.Resolve(path);
        if (!File.Exists(resolved))
        {
            return false;
        }

        _textures.Add(name, Raylib.LoadTexture(resolved));

        return true;
    }
}
