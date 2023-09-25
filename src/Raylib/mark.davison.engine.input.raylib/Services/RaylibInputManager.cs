namespace mark.davison.engine.input.raylib.Services;

public class RaylibInputManager : IInputManager
{
    public bool IsMouseButtonDown(MouseButton button)
    {
        return Raylib_cs.Raylib.IsMouseButtonDown(ToRaylib(button));
    }

    public bool IsMouseButtonPressed(MouseButton button)
    {
        return Raylib_cs.Raylib.IsMouseButtonPressed(ToRaylib(button));
    }

    public bool IsKeyDown(KeyboardKey key)
    {
        return Raylib_cs.Raylib.IsKeyDown(ToRaylib(key));
    }

    public bool IsKeyPressed(KeyboardKey key)
    {
        return Raylib_cs.Raylib.IsKeyPressed(ToRaylib(key));
    }

    public Vector2 GetMousePosition()
    {
        return Raylib_cs.Raylib.GetMousePosition();
    }

    private static Raylib_cs.MouseButton ToRaylib(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.MOUSE_BUTTON_LEFT:
                return Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT;
            case MouseButton.MOUSE_BUTTON_RIGHT:
                return Raylib_cs.MouseButton.MOUSE_BUTTON_RIGHT;
            case MouseButton.MOUSE_BUTTON_MIDDLE:
                return Raylib_cs.MouseButton.MOUSE_BUTTON_MIDDLE;
        }

        return (Raylib_cs.MouseButton)(-1);
    }

    private static Raylib_cs.KeyboardKey ToRaylib(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.KEY_LEFT_CONTROL:
                return Raylib_cs.KeyboardKey.KEY_LEFT_CONTROL;
            case KeyboardKey.KEY_RIGHT_CONTROL:
                return Raylib_cs.KeyboardKey.KEY_RIGHT_CONTROL;
            case KeyboardKey.KEY_LEFT_SHIFT:
                return Raylib_cs.KeyboardKey.KEY_LEFT_SHIFT;
            case KeyboardKey.KEY_RIGHT_SHIFT:
                return Raylib_cs.KeyboardKey.KEY_RIGHT_SHIFT;
            case KeyboardKey.KEY_LEFT_ALT:
                return Raylib_cs.KeyboardKey.KEY_LEFT_ALT;
            case KeyboardKey.KEY_RIGHT_ALT:
                return Raylib_cs.KeyboardKey.KEY_RIGHT_ALT;
        }

        return Raylib_cs.KeyboardKey.KEY_NULL;
    }
}
