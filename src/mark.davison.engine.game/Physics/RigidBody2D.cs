namespace mark.davison.engine.game.Physics;

public enum RigidBody2DType
{
    CIRCLE
}

public abstract class RigidBody2D : BaseComponent
{
    public abstract RigidBody2DType Type { get; }

    public bool Collides(RigidBody2D other)
    {
        if (Type == RigidBody2DType.CIRCLE &&
            other.Type == RigidBody2DType.CIRCLE)
        {
            var lhsCircle = this as CircleCollider;
            var rhsCircle = other as CircleCollider;

            if (lhsCircle != null && rhsCircle != null)
            {
                return DetectCircleCircle(
                    lhsCircle.Center + lhsCircle.Offset, lhsCircle.Radius,
                    rhsCircle.Center + rhsCircle.Offset, rhsCircle.Radius);
            }
        }
        else
        {
            throw new NotImplementedException($"Collision between {Type} and {other.Type} is not implemented");
        }

        return false;
    }

    internal bool DetectCircleCircle(Vector2 center1, float radius1, Vector2 center2, float radius2)
    {
        var distance = (center1 - center2).Length();
        var radiiSum = radius1 + radius2;

        return distance <= radiiSum;
    }
}
