namespace mark.davison.engine.examples.common.ECS.Prefabs;

public static class Prefabs
{
    public static IEntity CreatePlayerShip(IEntity e)
    {
        e.AddComponent<PlayerController>();
        var t = e.AddComponent<Transform>();
        t.Position = new Vector2(512.0f + 128.0f, 512.0f);
        var s = e.AddComponent<Sprite>();
        s.SpriteName = "playerShip1_blue";
        var c = e.AddComponent<CircleCollider>();
        c.Radius = 35.0f;
        c.Offset = new Vector2(0.0f, -10.0f);
        c.Transform = t;
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
