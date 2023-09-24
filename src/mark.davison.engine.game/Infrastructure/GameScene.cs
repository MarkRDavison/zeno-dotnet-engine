namespace mark.davison.engine.game.Infrastructure;

public abstract class GameScene<TGame, TRenderer> : IScene
    where TGame : class, IGame
    where TRenderer : class, IGameRenderer
{
    private readonly TGame _game;
    private readonly TRenderer _gameRenderer;

    protected GameScene(
        TGame game,
        TRenderer gameRenderer
    )
    {
        _game = game;
        _gameRenderer = gameRenderer;
    }

    public void Update(float delta)
    {
        _game.Update(delta);
        _gameRenderer.Update(delta);
    }

    public void Render()
    {
        _gameRenderer.Render();
    }
}
