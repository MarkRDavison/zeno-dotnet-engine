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

    public override void Init(GameExample game, GameRendererExample gameRenderer)
    {
        game.ECSWorld.AddSystem<BasicKinematicSystem>();
        game.ECSWorld.AddSystem<PlayerControllerSystem>();
        game.ECSWorld.AddSystem<ImmediateModeSpriteSystem>();

        {
            var e = game.ECSWorld.AddEntity("PLAYER_BLUE_1");
            e.AddComponent<PlayerController>();
            var t = e.AddComponent<Transform>();
            t.Position = new Vector2(512.0f + 128.0f, 512.0f);
            var s = e.AddComponent<Sprite>();
            s.SpriteName = "playerShip1_blue";
            var c = e.AddComponent<CircleCollider>();
            c.Radius = 35.0f;
            c.Offset = new Vector2(0.0f, -10.0f);
        }
        {
            var e = game.ECSWorld.AddEntity("ENEMY_GREEN_1");
            var t = e.AddComponent<Transform>();
            t.Position = new Vector2(256.0f, 128.0f);
            t.Rotation = 180.0f;
            var s = e.AddComponent<Sprite>();
            s.SpriteName = "enemyGreen1";
            s.OffsetRotation = 180.0f;
            var c = e.AddComponent<CircleCollider>();
            c.Radius = 35.0f;
        }
        {
            var e = game.ECSWorld.AddEntity("ENEMY_BLACK_1");
            var t = e.AddComponent<Transform>();
            t.Position = new Vector2(512.0f, 128.0f);
            t.Rotation = 180.0f;
            var s = e.AddComponent<Sprite>();
            s.SpriteName = "enemyBlack2";
            s.OffsetRotation = 180.0f;
            var c = e.AddComponent<CircleCollider>();
            c.Radius = 35.0f;
        }
        {
            var e = game.ECSWorld.AddEntity("ENEMY_BLUE_1");
            var t = e.AddComponent<Transform>();
            t.Position = new Vector2(768.0f, 128.0f);
            t.Rotation = 180.0f;
            var s = e.AddComponent<Sprite>();
            s.SpriteName = "enemyBlue3";
            s.OffsetRotation = 180.0f;
            var c = e.AddComponent<CircleCollider>();
            c.Radius = 35.0f;
        }
        {
            var e = game.ECSWorld.AddEntity("ENEMY_RED_1");
            var t = e.AddComponent<Transform>();
            t.Position = new Vector2(1024.0f, 128.0f);
            t.Rotation = 180.0f;
            var s = e.AddComponent<Sprite>();
            s.SpriteName = "enemyRed4";
            s.OffsetRotation = 180.0f;
            var c = e.AddComponent<CircleCollider>();
            c.Radius = 35.0f;
        }
    }
}
