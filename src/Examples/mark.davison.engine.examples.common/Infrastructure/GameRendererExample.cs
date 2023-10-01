using mark.davison.engine.game.ECS.Systems;

namespace mark.davison.engine.examples.common.Infrastructure;

public class GameRendererExample : IGameRenderer
{
    private readonly GameExample _game;
    private readonly ISpritesheetManager _spritesheetManager;
    private readonly IImmediateModeRenderer _immediateModeRenderer;

    public GameRendererExample(
        GameExample game,
        ISpritesheetManager spritesheetManager,
        IImmediateModeRenderer immediateModeRenderer
    )
    {
        _game = game;
        _spritesheetManager = spritesheetManager;
        _immediateModeRenderer = immediateModeRenderer;
    }

    public void Update(float delta)
    {

    }

    public void Render()
    {
        var sys = _game.ECSWorld.GetSystem<ImmediateModeSpriteSystem>();

        sys.Render(_immediateModeRenderer, _game.ECSWorld.Entities);
    }

}
