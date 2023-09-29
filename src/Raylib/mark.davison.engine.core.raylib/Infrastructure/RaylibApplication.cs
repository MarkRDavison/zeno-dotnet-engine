namespace mark.davison.engine.core.raylib.Infrastructure;

public class RaylibApplication : Application
{
    public RaylibApplication(
        IHostApplicationLifetime hostApplicationLifetime,
        IOptions<ApplicationConfiguration> applicationConfigurationOptions,
        IServiceProvider serviceProvider
    ) : base(
        hostApplicationLifetime,
        applicationConfigurationOptions,
        serviceProvider
    )
    {
    }

    public override void Initialise(string title)
    {
        Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
        Raylib.InitWindow(1440, 900, title);
        Raylib.InitAudioDevice();
    }

    public override float GetFrameTime() => Raylib.GetFrameTime();

    public override bool ShouldWindowClose() => Raylib.WindowShouldClose();

    public override void Teardown()
    {
        Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    public override void BeginRender()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.SKYBLUE);
    }

    public override void EndRender()
    {
        Raylib.EndDrawing();
    }
}
