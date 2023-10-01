namespace mark.davison.engine.core.abstractions.Infrastructure;

public interface IScene
{
    void Init();
    void Update(float delta);
    void Render();
}
