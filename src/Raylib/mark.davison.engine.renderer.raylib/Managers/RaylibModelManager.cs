using Model = mark.davison.engine.renderer.abstractions.Resources.Model;

namespace mark.davison.engine.renderer.raylib.Managers;

public class RaylibModelManager : IModelManager<Raylib_cs.Model>
{
    private readonly IDictionary<string, Raylib_cs.Model> _models;
    private readonly ITextureManager<Raylib_cs.Texture2D> _textureManager;

    public RaylibModelManager(ITextureManager<Texture2D> textureManager)
    {
        _models = new Dictionary<string, Raylib_cs.Model>();
        _textureManager = textureManager;
    }

    public Model GetModel(string name)
    {
        return new Model { Name = name };
    }

    public Raylib_cs.Model GetModelImplementation(string name)
    {
        if (_models.TryGetValue(name, out var model))
        {
            return model;
        }

        throw new InvalidOperationException("TODO"); // TODO: Add default model
    }

    public bool LoadModel(string name, string path)
    {
        var resolved = Files.Resolve(path);
        if (!File.Exists(resolved))
        {
            return false;
        }

        var newModel = Raylib.LoadModel(resolved);

        for (int i = 0; i < newModel.MaterialCount; ++i)
        {
            unsafe
            {
                var material = newModel.Materials[i];

                var map = material.Maps[(int)Raylib_cs.MaterialMapIndex.Diffuse];
                map.Color = Color.Magenta;
            }
        }

        _models.Add(name, newModel);

        return true;
    }
}
