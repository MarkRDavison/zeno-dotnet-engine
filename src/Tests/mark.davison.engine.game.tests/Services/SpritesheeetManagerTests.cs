namespace mark.davison_engine.game.tests.Services;

[TestClass]
public class SpritesheeetManagerTests
{
    private readonly SpritesheetManager _spritesheetManager;

    public SpritesheeetManagerTests()
    {
        _spritesheetManager = new SpritesheetManager();
    }

    [TestMethod]
    public void SingleCelledSprite_AtOrigin_CanBeRegisteredAndRetrieved()
    {
        const float CellSize = 64.0f;
        const string Sheet = "SHEET";
        const string Sprite = "SPRITE";

        _spritesheetManager.RegisterSheet(Sheet, CellSize);
        _spritesheetManager.RegisterSprite(Sheet, Sprite, 0, 0, 1, 1);

        var bounds = _spritesheetManager.GetSpriteBounds(Sheet, Sprite);

        Assert.AreEqual(0, bounds.X);
        Assert.AreEqual(0, bounds.Y);
        Assert.AreEqual(CellSize, bounds.Width);
        Assert.AreEqual(CellSize, bounds.Height);
    }

    [TestMethod]
    public void SingleCelledSprite_NotAtOrigin_CanBeRegisteredAndRetrieved()
    {
        const float CellSize = 64.0f;
        const string Sheet = "SHEET";
        const string Sprite = "SPRITE";

        _spritesheetManager.RegisterSheet(Sheet, CellSize);
        _spritesheetManager.RegisterSprite(Sheet, Sprite, 1, 1, 1, 1);

        var bounds = _spritesheetManager.GetSpriteBounds(Sheet, Sprite);

        Assert.AreEqual(CellSize, bounds.X);
        Assert.AreEqual(CellSize, bounds.Y);
        Assert.AreEqual(CellSize, bounds.Width);
        Assert.AreEqual(CellSize, bounds.Height);
    }

    [TestMethod]
    public void NonSingleCelledSprite_NotAtOrigin_CanBeRegisteredAndRetrieved()
    {
        const float CellSize = 64.0f;
        const string Sheet = "SHEET";
        const string Sprite = "SPRITE";

        _spritesheetManager.RegisterSheet(Sheet, CellSize);
        _spritesheetManager.RegisterSprite(Sheet, Sprite, 1, 1, 2, 1);

        var bounds = _spritesheetManager.GetSpriteBounds(Sheet, Sprite);

        Assert.AreEqual(CellSize, bounds.X);
        Assert.AreEqual(CellSize, bounds.Y);
        Assert.AreEqual(CellSize * 2.0f, bounds.Width);
        Assert.AreEqual(CellSize, bounds.Height);
    }
}
