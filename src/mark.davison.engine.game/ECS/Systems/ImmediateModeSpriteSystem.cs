namespace mark.davison.engine.game.ECS.Systems;

public class ImmediateModeSpriteSystem : ISystem
{
    private readonly ISpritesheetManager _spritesheetManager;

    public ImmediateModeSpriteSystem(ISpritesheetManager spritesheetManager)
    {
        _spritesheetManager = spritesheetManager;
    }

    public void Update(float delta, IEnumerable<IEntity> entities)
    {

    }

    public Vector2 ToDirection(float rotation)
    {
        var (sin, cos) = Math.SinCos(rotation * (float)Math.PI / 180.0f);
        return new((float)sin, (float)-cos);
    }

    public void Render(IImmediateModeRenderer renderer, IEnumerable<IEntity> entities)
    {
        foreach (var e in entities)
        {
            var t = e.GetComponent<Transform>();
            var s = e.GetComponent<Sprite>();

            if (t == null || s == null)
            {
                continue;
            }

            RenderSpritesheetQuad(renderer, "space-shooter", s.SpriteName, t.Position, t.Rotation + s.OffsetRotation);

            var dir = ToDirection(t.Rotation);

            renderer.RenderLine(t.Position, t.Position + dir * 128.0f, Colour.BLACK);

            var cc = e.GetComponent<CircleCollider>();

            if (cc != null)
            {
                renderer.RenderCircleOutline(t.Position + dir * cc.Offset.Y, cc.Radius, Colour.WHITE);
            }
        }
    }
    private void RenderSpritesheetQuad(IImmediateModeRenderer renderer, string textureName, string spriteName, Vector2 position, float rotation, Vector2? size = null)
    {
        var spriteBounds = _spritesheetManager.GetSpriteBounds(textureName, spriteName);

        var bounds = new Rect(position.X, position.Y, size?.X ?? spriteBounds.Width, size?.Y ?? spriteBounds.Height);

        renderer.RenderQuad(
            bounds,
            spriteBounds,
            textureName,
            rotation,
            new Vector2(bounds.Width / 2.0f, bounds.Height / 2.0f),
            Colour.WHITE);

    }

    public Func<string?, IEntity>? CreateEntityFunc { get; set; }
}
