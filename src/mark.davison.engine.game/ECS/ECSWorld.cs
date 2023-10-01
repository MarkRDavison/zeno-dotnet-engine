namespace mark.davison.engine.game.ECS;

public class ECSWorld
{
    private readonly IServiceProvider _provider;

    public ECSWorld(IServiceProvider provider)
    {
        _provider = provider;
    }

    public List<IEntity> Entities { get; } = new();

    public List<ISystem> Systems { get; } = new();

    public void Update(float delta)
    {
        foreach (var system in Systems)
        {
            system.Update(delta, Entities);
        }
    }

    public void AddSystem<TSystem>() where TSystem : class, ISystem
    {
        AddSystem(_provider.GetRequiredService<TSystem>());
    }

    public void AddSystem<TSystem>(TSystem system) where TSystem : class, ISystem
    {
        system.CreateEntityFunc = AddEntity;
        Systems.Add(system);
    }

    public TSystem GetSystem<TSystem>() where TSystem : class, ISystem
    {
        return Systems.Where(_ => _ as TSystem != null).Cast<TSystem>().FirstOrDefault() ?? throw new InvalidOperationException($"ECSWorld does not have a system of type '{typeof(TSystem).Name}'");
    }

    public IEntity AddEntity(string? name = null)
    {
        var e = new Entity();
        e.Id = Guid.NewGuid();
        e.Name = name ?? e.Id.ToString();
        Entities.Add(e);
        return e;
    }
}
