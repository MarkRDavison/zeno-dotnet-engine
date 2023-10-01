namespace mark.davison.engine.examples.common.Infrastructure;

public class GameExample : IGame
{
    public GameExample(ECSWorld ecsWorld)
    {
        ECSWorld = ecsWorld;
    }
    public void Update(float delta)
    {
        ECSWorld.Update(delta);
    }

    public ECSWorld ECSWorld { get; init; }
}
