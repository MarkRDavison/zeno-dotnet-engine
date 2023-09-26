namespace mark.davison.engine.game.Services;

public class SpritesheetManager : ISpritesheetManager
{
    private class SpriteRegistration
    {
        public required string Name { get; init; }
        public required int X { get; init; }
        public required int Y { get; init; }
        public required int Width { get; init; }
        public required int Height { get; init; }
    }

    private readonly IDictionary<string, float> _sheetCellSizes = new Dictionary<string, float>();
    private readonly IDictionary<string, List<SpriteRegistration>> _spriteRegistrations = new Dictionary<string, List<SpriteRegistration>>();


    public void RegisterSheet(string name, float cellSize)
    {
        _sheetCellSizes[name] = cellSize;
    }

    public void RegisterSprite(string sheetName, string spriteName, int cellX, int cellY, int cellWidth, int cellHeight)
    {
        if (!_spriteRegistrations.ContainsKey(sheetName))
        {
            _spriteRegistrations[sheetName] = new List<SpriteRegistration>();
        }

        _spriteRegistrations[sheetName].Add(new SpriteRegistration
        {
            Name = spriteName,
            X = cellX,
            Y = cellY,
            Width = cellWidth,
            Height = cellHeight
        });
    }

    public Rect GetSpriteBounds(string sheetName, string spriteName)
    {

        if (_sheetCellSizes.TryGetValue(sheetName, out var cellSize) &&
            _spriteRegistrations.TryGetValue(sheetName, out var sprites))
        {
            var registration = sprites.FirstOrDefault(_ => _.Name == spriteName);

            if (registration != null)
            {
                return new Rect(
                    cellSize * registration.X,
                    cellSize * registration.Y,
                    cellSize * registration.Width,
                    cellSize * registration.Height);
            }
        }

        return new Rect();
    }
}
