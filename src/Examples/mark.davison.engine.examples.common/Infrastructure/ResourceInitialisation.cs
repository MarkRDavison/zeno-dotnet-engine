using System.Xml;

namespace mark.davison.engine.examples.common.Infrastructure;

public static class ResourceInitialisation
{
    public static void InitResources(this IServiceProvider provider)
    {
        Files.AddHintPath("C:/Workspace/Git/zeno-dotnet-engine");
        InitTextures(provider);
        InitSpritesheets(provider);
    }

    private static void InitTextures(IServiceProvider provider)
    {
        var tm = provider.GetRequiredService<ITextureManager>();

        LoadTexture(tm, "spritesheet", "resources/textures/spritesheet.png");
        LoadTexture(tm, "space-shooter", "resources/textures/space-shooter/sheet.png");
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
