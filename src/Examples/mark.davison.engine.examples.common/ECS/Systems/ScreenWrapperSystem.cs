namespace mark.davison.engine.examples.common.ECS.Systems;

public class ScreenWrapperSystem : ISystem
{
    private readonly IRendererInstance _rendererInstance;

    public ScreenWrapperSystem(IRendererInstance rendererInstance)
    {
        _rendererInstance = rendererInstance;
    }

    public Func<string?, IEntity>? CreateEntityFunc { get; set; }
    public Action<IEntity>? AddEntityFunc { get; set; }

    public void Update(float delta, IEnumerable<IEntity> entities)
    {
        var size = _rendererInstance.GetWindowSize();
        foreach (var entity in entities)
        {
            var transform = entity.GetComponent<Transform>();
            if (transform == null)
            {
                continue;
            }

            if (transform.Position.X < 0.0f)
            {
                transform.Position = new Vector2(transform.Position.X + size.X, transform.Position.Y);
            }
            else if (transform.Position.X >= size.X)
            {
                transform.Position = new Vector2(transform.Position.X - size.X, transform.Position.Y);
            }
            if (transform.Position.Y < 0.0f)
            {
                transform.Position = new Vector2(transform.Position.X, transform.Position.Y + size.Y);
            }
            else if (transform.Position.Y >= size.Y)
            {
                transform.Position = new Vector2(transform.Position.X, transform.Position.Y - size.Y);
            }
        }
    }
}
