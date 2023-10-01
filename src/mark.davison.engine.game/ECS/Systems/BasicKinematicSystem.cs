namespace mark.davison.engine.game.ECS.Systems;

public class BasicKinematicSystem : ISystem
{
    public Func<string?, IEntity>? CreateEntityFunc { get; set; }

    public void Update(float delta, IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities.ToList()) // TODO: Dont ToList()
        {
            var t = entity.GetComponent<Transform>();
            var k = entity.GetComponent<Kinematic>();

            if (t == null || k == null)
            {
                continue;
            }

            t.Position += k.Velocity * delta;
            k.Velocity += k.Acceleration * delta;
        }
    }
}
