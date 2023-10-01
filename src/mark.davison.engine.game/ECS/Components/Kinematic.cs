namespace mark.davison.engine.game.ECS.Components;

public class Kinematic : BaseComponent
{
    public override string Name => nameof(Kinematic);

    public Vector2 Velocity { get; set; }
    public Vector2 Acceleration { get; set; }
}
