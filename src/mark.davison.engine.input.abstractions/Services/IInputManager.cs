namespace mark.davison.engine.input.abstractions.Services;

public interface IInputManager
{
    bool IsKeyDown(KeyboardKey key);
    bool IsKeyPressed(KeyboardKey key);
    bool IsMouseButtonDown(MouseButton button);
    bool IsMouseButtonPressed(MouseButton button);
    Vector2 GetMousePosition();
}
