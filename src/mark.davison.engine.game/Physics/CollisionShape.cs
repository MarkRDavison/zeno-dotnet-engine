namespace mark.davison.engine.game.Physics;

public enum CollisionShapeType
{
    CIRCLE
}

public abstract class CollisionShape : BaseComponent
{
    public abstract CollisionShapeType Type { get; }

    public bool Collides(CollisionShape other)
    {
        if (Type == CollisionShapeType.CIRCLE &&
            other.Type == CollisionShapeType.CIRCLE)
        {
            var lhsCircle = this as CircleCollider;
            var rhsCircle = other as CircleCollider;

            if (lhsCircle != null && rhsCircle != null)
            {
                return DetectCircleCircle(
                    (lhsCircle.Transform?.Position ?? lhsCircle.Center) + lhsCircle.Offset, lhsCircle.Radius,
                    (rhsCircle.Transform?.Position ?? rhsCircle.Center) + rhsCircle.Offset, rhsCircle.Radius);
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
