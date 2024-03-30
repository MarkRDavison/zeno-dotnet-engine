namespace mark.davison.engine.renderer.raylib.Managers;

public class RaylibTextureManager : ITextureManager<Texture2D>, IDisposable
{
    private readonly IDictionary<string, Texture2D> _textures;
    private bool disposedValue;

    public RaylibTextureManager()
    {
        Image isChecked = Raylib.GenImageChecked(64, 64, 8, 8, Color.Red, Color.Green);
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
            Size = new Vector2(texture.Width, texture.Height)
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

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                foreach (var (name, texture) in _textures)
                {
                    Raylib.UnloadTexture(texture);
                }

                _textures.Clear();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
