namespace mark.davison.engine.game.Services.Interfaces;

public interface ISpritesheetManager
{
    void RegisterSheet(string name, float cellSize);
    void RegisterSprite(string sheetName, string spriteName, int cellX, int cellY, int cellWidth, int cellHeight);
    Rect GetSpriteBounds(string sheetName, string spriteName);
}
