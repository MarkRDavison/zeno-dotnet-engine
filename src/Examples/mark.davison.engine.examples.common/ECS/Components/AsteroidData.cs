namespace mark.davison.engine.examples.common.ECS.Components;

public class AsteroidData : BaseComponent
{
    public override string Name => nameof(AsteroidData);
    public AsteroidSize Size { get; set; }
    public AsteroidType Type { get; set; }
}
