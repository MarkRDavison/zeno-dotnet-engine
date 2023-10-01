namespace mark.davison.engine.examples.common.ECS.Systems;

public class PlayerControllerSystem : ISystem
{
    private readonly IInputActionManager _inputActionManager;

    public PlayerControllerSystem(IInputActionManager inputActionManager)
    {
        _inputActionManager = inputActionManager;
    }

    public Func<string?, IEntity>? CreateEntityFunc { get; set; }

    public void Update(float delta, IEnumerable<IEntity> entities)
    {
        foreach (IEntity entity in entities.ToList()) // TODO: New entities are added to a list, not added to the collection etc...
        {
            var pc = entity.GetComponent<PlayerController>();
            if (pc == null) { continue; }
            var t = entity.GetRequiredComponent<Transform>();
            var c = entity.GetRequiredComponent<CircleCollider>();

            if (_inputActionManager.IsActionInvoked("ROTATE_CW"))
            {
                t.Rotation += pc.RotationSpeed * delta;
            }

            if (_inputActionManager.IsActionInvoked("ROTATE_CCW"))
            {
                t.Rotation -= pc.RotationSpeed * delta;
            }

            if (_inputActionManager.IsActionInvoked("THRUST"))
            {
                var dir = t.Rotation.ToDirection();
                t.Position += dir * delta * pc.Speed;
                c.Center = t.Position;
            }

            if (_inputActionManager.IsActionInvoked("FIRE"))
            {
                if (CreateEntityFunc != null)
                {
                    Prefabs.Prefabs.CreatePlayerBullet(CreateEntityFunc(null), t.Position + t.Rotation.ToDirection() * 50.0f, t.Rotation);
                }
            }
        }
    }
}
