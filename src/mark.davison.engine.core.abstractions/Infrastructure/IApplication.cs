namespace mark.davison.engine.core.abstractions.Infrastructure;

public interface IApplication
{
    void Initialise(string title);
    void Start();
    void Stop();
    bool ShouldWindowClose();

    void SetScene(IScene scene);
}
