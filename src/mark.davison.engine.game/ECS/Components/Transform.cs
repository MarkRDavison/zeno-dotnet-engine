namespace mark.davison.engine.game.ECS.Components;

public class Transform : BaseComponent
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; }
    public float Scale { get; set; } = 1.0f;

    public override string Name => nameof(Transform);
}
