namespace mark.davison.engine.common.Utility;

public static class Files
{
    private static List<string> _hintPaths = new();

    public static void AddHintPath(string path)
    {
        _hintPaths.Add(path);
    }

    public static string Resolve(string path)
    {
        if (File.Exists(path))
        {
            return path;
        }

        foreach (var hint in _hintPaths)
        {
            var full = Path.Combine(hint, path);
            if (File.Exists(full))
            {
                return full;
            }
        }

        return path;
    }
}
