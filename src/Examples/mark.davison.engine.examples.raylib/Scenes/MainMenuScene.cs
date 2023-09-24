namespace mark.davison.engine.examples.raylib.Scenes;

[SceneRegistration(Name = Scenes.MainMenu)]
public class MainMenuScene : IScene
{
    public void Update(float delta)
    {
        Console.WriteLine("MAIN MENU");
    }

    public void Render()
    {

    }
}
