namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.Game)]
public class GameScene : GameScene<GameExample, GameRendererExample>
{
    public GameScene(
        GameExample game,
        GameRendererExample gameRenderer
    ) : base(game, gameRenderer)
    {
    }
}
