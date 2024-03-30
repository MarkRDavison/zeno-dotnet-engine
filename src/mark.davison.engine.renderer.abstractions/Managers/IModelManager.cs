namespace mark.davison.engine.renderer.abstractions.Managers;

public interface IModelManager
{
    bool LoadModel(string name, string path);
    Model GetModel(string name);
}

public interface IModelManager<TModel> : IModelManager
{
    TModel GetModelImplementation(string name);
}
