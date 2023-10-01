namespace mark.davison.engine.game.ECS.Components;

public abstract class BaseComponent : IComponent
{
    public Guid Id { get; set; }
    public Guid EntityId { get; set; }
    public abstract string Name { get; }
}
