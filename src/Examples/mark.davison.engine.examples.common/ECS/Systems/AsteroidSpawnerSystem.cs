namespace mark.davison.engine.examples.common.ECS.Systems;

public class AsteroidSpawnerSystem : ISystem
{
    private float _spawnTime;
    public Func<string?, IEntity>? CreateEntityFunc { get; set; }

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

        }
    }
}
