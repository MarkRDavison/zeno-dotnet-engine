namespace mark.davison.engine.renderer.abstractions.Managers;

public interface ISoundManager
{
    bool LoadSound(string name, string path);
    void PlaySound(string name);
}
