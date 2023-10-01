namespace mark.davison.engine.game.ECS;

public interface IEntity
{
    Guid Id { get; set; }
    string Name { get; set; }

    TComponent? GetComponent<TComponent>() where TComponent : class, IComponent;
    TComponent GetRequiredComponent<TComponent>() where TComponent : class, IComponent;
    TComponent AddComponent<TComponent>() where TComponent : IComponent, new();
    TComponent AddComponent<TComponent>(TComponent component) where TComponent : IComponent;
    void RemoveComponent<TComponent>() where TComponent : IComponent;
    void RemoveComponent<TComponent>(TComponent component) where TComponent : IComponent;
}
