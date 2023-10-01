namespace mark.davison.engine.game.ECS;

public class Entity : IEntity
{
    private readonly IDictionary<Type, IComponent> _componentsByType = new Dictionary<Type, IComponent>();

    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;

    public TComponent AddComponent<TComponent>() where TComponent : IComponent, new()
    {
        return AddComponent(new TComponent());
    }

    public TComponent AddComponent<TComponent>(TComponent component) where TComponent : IComponent
    {
        if (_componentsByType.TryGetValue(typeof(TComponent), out var existing))
        {
            RemoveComponent(existing);
        }

        component.EntityId = Id;
        _componentsByType[typeof(TComponent)] = component;
        return component;
    }

    public TComponent? GetComponent<TComponent>() where TComponent : class, IComponent
    {
        if (_componentsByType.TryGetValue(typeof(TComponent), out var existing))
        {
            return (TComponent?)existing;
        }

        return (TComponent?)null;
    }

    public TComponent GetRequiredComponent<TComponent>() where TComponent : class, IComponent
    {
        var component = GetComponent<TComponent>();
        if (component != null)
        {
            return component;
        }

        throw new InvalidOperationException($"Entity {Name} ({Id}) does not have a component of type {typeof(TComponent).Name}");
    }

    public void RemoveComponent<TComponent>() where TComponent : IComponent
    {
        _componentsByType.Remove(typeof(TComponent));
    }

    public void RemoveComponent<TComponent>(TComponent component) where TComponent : IComponent
    {
        if (_componentsByType.TryGetValue(typeof(TComponent), out var existing))
        {
            if (ReferenceEquals(component, existing))
            {
                _componentsByType.Remove(typeof(TComponent));
            }
        }
    }
}
