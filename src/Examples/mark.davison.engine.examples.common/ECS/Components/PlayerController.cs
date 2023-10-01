namespace mark.davison.engine.examples.common.ECS.Components;

public class PlayerController : BaseComponent
{
    public override string Name => nameof(PlayerController);

    public float Speed { get; set; } = 512.0f;

    public float RotationSpeed { get; set; } = (float)Math.PI * 100.0f;
}
