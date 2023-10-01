using mark.davison.engine.examples.common.Helpers;

namespace mark.davison.engine.examples.common.ECS.Systems;

public class PlayerControllerSystem : ISystem
{
    private readonly IInputActionManager _inputActionManager;

    public PlayerControllerSystem(IInputActionManager inputActionManager)
    {
        _inputActionManager = inputActionManager;
    }

    public void Update(float delta, IEnumerable<IEntity> entities)
    {
        foreach (IEntity entity in entities)
        {
            var pc = entity.GetComponent<PlayerController>();
            if (pc == null) { continue; }
            var t = entity.GetRequiredComponent<Transform>();

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
            }
        }
    }
}
