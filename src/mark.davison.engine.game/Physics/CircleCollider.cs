namespace mark.davison.engine.game.Physics;

public class CircleCollider : RigidBody2D
{
    public override string Name => nameof(CircleCollider);
    public override RigidBody2DType Type => RigidBody2DType.CIRCLE;

    public Vector2 Center { get; set; }
    public Vector2 Offset { get; set; }
    public float Radius { get; set; }

}
