namespace mark.davison.engine.core.abstractions.Services;

public interface ISceneTransitionService
{
    void SetScene(string name);
    void RegisterScene<TScene>(string name) where TScene : class, IScene;
}
