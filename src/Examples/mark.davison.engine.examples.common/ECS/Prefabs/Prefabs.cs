namespace mark.davison.engine.examples.common.ECS.Prefabs;

public static class Prefabs
{
    public static IEntity CreatePlayerShip()
    {
        var e = new Entity();
        return e;
    }

    public static void CreatePlayerBullet(IEntity entity, Vector2 spawnPosition, float rotation)
    {
        var t = entity.AddComponent<Transform>();
        t.Position = spawnPosition;
        t.Rotation = rotation;
        var cc = entity.AddComponent<CircleCollider>();
        cc.Radius = 8.0f;
        var s = entity.AddComponent<Sprite>();
        s.SpriteName = "laserBlue02";
        var k = entity.AddComponent<Kinematic>();
        k.Velocity = rotation.ToDirection() * 768.0f;
    }
}
