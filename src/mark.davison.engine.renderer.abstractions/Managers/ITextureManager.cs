namespace mark.davison.engine.renderer.abstractions.Managers;

public interface ITextureManager
{
    bool LoadTexture(string name, string path);
    Texture GetTexture(string name);
}

public interface ITextureManager<TTexture> : ITextureManager
{
    TTexture GetTextureImplementation(string name);
}
