namespace mark.davison.engine.game.ECS;

public interface IComponent
{
    public Guid Id { get; set; }
    public string Name { get; }
    public Guid EntityId { get; set; }
}
