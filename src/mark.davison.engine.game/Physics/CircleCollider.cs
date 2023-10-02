namespace mark.davison.engine.game.Physics;

public class CircleCollider : CollisionShape
{
    public override string Name => nameof(CircleCollider);
    public override CollisionShapeType Type => CollisionShapeType.CIRCLE;

    public Vector2 Center { get; set; }
    public Vector2 Offset { get; set; }
    public float Radius { get; set; }
    public Transform? Transform { get; set; }

}
