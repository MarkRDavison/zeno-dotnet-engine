namespace mark.davison.engine.renderer.raylib.Managers;

public class RaylibSoundManager : ISoundManager, IDisposable
{
    private readonly IDictionary<string, Sound> _sounds;
    private bool disposedValue;

    public RaylibSoundManager()
    {
        _sounds = new Dictionary<string, Sound>();
    }

    public bool LoadSound(string name, string path)
    {
        if (_sounds.TryGetValue(name, out var s))
        {
            Raylib.UnloadSound(s);
        }

        var soundPath = Files.Resolve(path);

        if (!string.IsNullOrEmpty(soundPath))
        {
            _sounds[name] = Raylib.LoadSound(soundPath);
            return true;
        }

        return false;
    }

    public void PlaySound(string name)
    {
        if (_sounds.TryGetValue(name, out var sound))
        {
            Raylib.PlaySound(sound);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                foreach (var (name, sound) in _sounds)
                {
                    Raylib.UnloadSound(sound);
                }

                _sounds.Clear();
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
