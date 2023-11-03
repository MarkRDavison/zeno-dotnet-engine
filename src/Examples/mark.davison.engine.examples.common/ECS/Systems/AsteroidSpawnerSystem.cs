namespace mark.davison.engine.examples.common.ECS.Systems;

public class AsteroidSpawnerSystem : ISystem
{
    private float _spawnTime;
    public Func<string?, IEntity>? CreateEntityFunc { get; set; }
    public Action<IEntity>? AddEntityFunc { get; set; }

    private readonly IRendererInstance _rendererInstance;

    public AsteroidSpawnerSystem(IRendererInstance rendererInstance)
    {
        _rendererInstance = rendererInstance;
    }

    public void Update(float delta, IEnumerable<IEntity> entities)
    {
        _spawnTime -= delta;

        if (_spawnTime < 0.0f)
        {
            _spawnTime += 5.0f;

            var existingAsteroids = entities
                .Select(_ => new
                {
                    Entity = _,
                    Asteroid = _.GetComponent<AsteroidData>()
                })
                .Where(_ => _.Asteroid != null)
                .ToList();

            if (!existingAsteroids.Any())
            {
                var windowSize = _rendererInstance.GetWindowSize();
                var margin = 100;

                foreach (var asteroid in new[]
                {
                    AsteroidFactory.CreateAsteroid(AsteroidSize.BIG),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.BIG),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.BIG),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.MEDIUM),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.MEDIUM),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.SMALL),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.SMALL),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.TINY),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.TINY),
                    AsteroidFactory.CreateAsteroid(AsteroidSize.TINY)
                })
                {
                    var transform = asteroid.GetRequiredComponent<Transform>();
                    transform.Position = new Vector2(
                        Random.Shared.Next(margin, (int)windowSize.X - margin),
                        Random.Shared.Next(margin, (int)windowSize.Y - margin)
                    );

                    if (AddEntityFunc != null)
                    {
                        AddEntityFunc(asteroid);
                    }
                }

            }
        }
    }
}
