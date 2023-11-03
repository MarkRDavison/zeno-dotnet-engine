namespace mark.davison.engine.examples.common.ECS.Prefabs;

public enum AsteroidSize
{
    TINY = 0,
    SMALL = 1,
    MEDIUM = 2,
    BIG = 3
}
public enum AsteroidType
{
    BROWN,
    GREY,
    RANDOM
}

public static class AsteroidFactory
{
    private static Vector2 ToDirection(float rotation)
    {
        var (sin, cos) = Math.SinCos(rotation * (float)Math.PI / 180.0f);
        return new((float)sin, (float)-cos);
    }

    private static readonly Dictionary<AsteroidType, Dictionary<AsteroidSize, List<string>>> _asteroids;
    static AsteroidFactory()
    {
        _asteroids = new()
        {
            { AsteroidType.BROWN, new()
                {
                    { AsteroidSize.BIG, new() { "meteorBrown_big1", "meteorBrown_big2", "meteorBrown_big3", "meteorBrown_big4" } },
                    { AsteroidSize.MEDIUM, new() { "meteorBrown_med1", "meteorBrown_med3" }  },
                    { AsteroidSize.SMALL, new() { "meteorBrown_small1", "meteorBrown_small2" }  },
                    { AsteroidSize.TINY, new() { "meteorBrown_tiny1", "meteorBrown_tiny2" }  }
                }
            },
            { AsteroidType.GREY, new()
                {
                    { AsteroidSize.BIG, new() { "meteorGrey_big1", "meteorGrey_big2", "meteorGrey_big3", "meteorGrey_big4" } },
                    { AsteroidSize.MEDIUM, new() { "meteorGrey_med1", "meteorGrey_med2" }  },
                    { AsteroidSize.SMALL, new() { "meteorGrey_small1", "meteorGrey_small2" }  },
                    { AsteroidSize.TINY, new() { "meteorGrey_tiny1", "meteorGrey_tiny2" }  }
                }
            }
        };
    }

    public static IEntity CreateAsteroid(AsteroidSize size, AsteroidType type = AsteroidType.RANDOM)
    {
        // TODO: BETTER RANDOM
        if (type == AsteroidType.RANDOM)
        {
            type = Random.Shared.Next(10) < 5 ? AsteroidType.BROWN : AsteroidType.GREY;
        }

        var potentialNames = _asteroids[type][size];

        var name = potentialNames.ElementAt(Random.Shared.Next(potentialNames.Count));

        var e = new Entity();
        var a = e.AddComponent<AsteroidData>();
        a.Type = type;
        a.Size = size;
        var t = e.AddComponent<Transform>();
        t.Rotation = (float)(Random.Shared.NextDouble() * 360.0f);
        var s = e.AddComponent<Sprite>();
        s.SpriteName = name;
        var k = e.AddComponent<Kinematic>();
        k.Velocity = ToDirection(t.Rotation) * 50.0f;
        var c = e.AddComponent<CircleCollider>();
        c.Transform = t;
        c.Radius = 45.0f;

        if (size == AsteroidSize.MEDIUM)
        {
            c.Radius = 20.0f;
        }
        if (size == AsteroidSize.SMALL)
        {
            c.Radius = 15.0f;
        }
        if (size == AsteroidSize.TINY)
        {
            c.Radius = 10.0f;
        }


        return e;
    }
}
