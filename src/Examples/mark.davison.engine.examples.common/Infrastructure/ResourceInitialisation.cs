using System.Xml;

namespace mark.davison.engine.examples.common.Infrastructure;

public static class ResourceInitialisation
{
    public static void InitResources(this IServiceProvider provider)
    {
        // TODO: Move this to config?
        Files.AddHintPath("C:/Workspace/Git/zeno-dotnet-engine");
        Files.AddHintPath("F:/Workspace/Github/zeno-dotnet-engine");

        InitTextures(provider);
        InitSpritesheets(provider);
        InitSounds(provider);
        InitModels(provider);
    }

    private static void InitTextures(IServiceProvider provider)
    {
        var tm = provider.GetRequiredService<ITextureManager>();

        LoadTexture(tm, "spritesheet", "resources/textures/spritesheet.png");
        LoadTexture(tm, "space-shooter", "resources/textures/space-shooter/sheet.png");
    }

    private static void InitSounds(IServiceProvider provider)
    {
        var sm = provider.GetRequiredService<ISoundManager>();

        LoadSound(sm, "laser1", "resources/sounds/sfx_laser1.ogg");
        LoadSound(sm, "laser2", "resources/sounds/sfx_laser2.ogg");
        LoadSound(sm, "lose", "resources/sounds/sfx_lose.ogg");
        LoadSound(sm, "shield_down", "resources/sounds/sfx_shieldDown.ogg");
        LoadSound(sm, "shield_up", "resources/sounds/sfx_shieldUp.ogg");
        LoadSound(sm, "two_tone", "resources/sounds/sfx_twoTone.ogg");
        LoadSound(sm, "zap", "resources/sounds/sfx_zap.ogg");
    }

    private static void InitModels(IServiceProvider provider)
    {
        var mm = provider.GetRequiredService<IModelManager>();

        LoadModel(mm, "satelliteDish_large", "resources/models/satelliteDish_large.obj");
    }

    private static void LoadModel(IModelManager mm, string modelName, string modelPath)
    {
        if (!mm.LoadModel(modelName, modelPath))
        {
            throw new InvalidOperationException($"Could not find model: {modelName} at '{modelPath}'");
        }
    }

    private static void LoadSound(ISoundManager sm, string soundName, string soundPath)
    {
        if (!sm.LoadSound(soundName, soundPath))
        {
            throw new InvalidOperationException($"Could not find sound: {soundName} at '{soundPath}'");
        }
    }

    private static void LoadTexture(ITextureManager tm, string textureName, string texturePath)
    {
        if (!tm.LoadTexture(textureName, texturePath))
        {
            throw new InvalidOperationException($"Could not find texture: {textureName} at '{texturePath}'");
        }
    }

    private static void InitSpritesheets(IServiceProvider provider)
    {
        var sm = provider.GetRequiredService<ISpritesheetManager>();

        sm.RegisterSheet("spritesheet", 32.0f);
        sm.RegisterSprite("spritesheet", "test", 0, 0, 1, 1);

        sm.RegisterSheet("space-shooter", 1.0f);

        var sheetLocation = Files.Resolve("resources/textures/space-shooter/sheet.xml");


        XmlDocument doc = new XmlDocument();
        doc.Load(sheetLocation);
        if (doc.DocumentElement != null)
        {
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var name = node.Attributes?["name"]?.Value ?? string.Empty;
                var x = int.Parse(node.Attributes?["x"]?.Value ?? "0");
                var y = int.Parse(node.Attributes?["y"]?.Value ?? "0");
                var width = int.Parse(node.Attributes?["width"]?.Value ?? "0");
                var height = int.Parse(node.Attributes?["height"]?.Value ?? "0");

                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                sm.RegisterSprite("space-shooter", name.Replace(".png", string.Empty), x, y, width, height);
            }
        }
    }
}
