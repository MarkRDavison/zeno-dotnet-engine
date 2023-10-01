namespace mark.davison.engine.game.ECS.Components;

public class Sprite : BaseComponent
{
    public override string Name => nameof(Sprite);

    public string SpriteName { get; set; } = string.Empty;
    public float OffsetRotation { get; set; }
}
