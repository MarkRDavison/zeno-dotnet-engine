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
            case MouseButton.MOUSE_BUTTON_LEFT: return Raylib_cs.MouseButton.MOUSE_BUTTON_LEFT;
            case MouseButton.MOUSE_BUTTON_RIGHT: return Raylib_cs.MouseButton.MOUSE_BUTTON_RIGHT;
            case MouseButton.MOUSE_BUTTON_MIDDLE: return Raylib_cs.MouseButton.MOUSE_BUTTON_MIDDLE;
            case MouseButton.MOUSE_BUTTON_SIDE: return Raylib_cs.MouseButton.MOUSE_BUTTON_SIDE;
            case MouseButton.MOUSE_BUTTON_EXTRA: return Raylib_cs.MouseButton.MOUSE_BUTTON_EXTRA;
            case MouseButton.MOUSE_BUTTON_FORWARD: return Raylib_cs.MouseButton.MOUSE_BUTTON_FORWARD;
            case MouseButton.MOUSE_BUTTON_BACK: return Raylib_cs.MouseButton.MOUSE_BUTTON_BACK;
            default:
                return (Raylib_cs.MouseButton)(-1);
        }

    }

    private static Raylib_cs.KeyboardKey ToRaylib(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.KEY_APOSTROPHE: return Raylib_cs.KeyboardKey.KEY_APOSTROPHE;
            case KeyboardKey.KEY_COMMA: return Raylib_cs.KeyboardKey.KEY_COMMA;
            case KeyboardKey.KEY_MINUS: return Raylib_cs.KeyboardKey.KEY_MINUS;
            case KeyboardKey.KEY_PERIOD: return Raylib_cs.KeyboardKey.KEY_PERIOD;
            case KeyboardKey.KEY_SLASH: return Raylib_cs.KeyboardKey.KEY_SLASH;
            case KeyboardKey.KEY_ZERO: return Raylib_cs.KeyboardKey.KEY_ZERO;
            case KeyboardKey.KEY_ONE: return Raylib_cs.KeyboardKey.KEY_ONE;
            case KeyboardKey.KEY_TWO: return Raylib_cs.KeyboardKey.KEY_TWO;
            case KeyboardKey.KEY_THREE: return Raylib_cs.KeyboardKey.KEY_THREE;
            case KeyboardKey.KEY_FOUR: return Raylib_cs.KeyboardKey.KEY_FOUR;
            case KeyboardKey.KEY_FIVE: return Raylib_cs.KeyboardKey.KEY_FIVE;
            case KeyboardKey.KEY_SIX: return Raylib_cs.KeyboardKey.KEY_SIX;
            case KeyboardKey.KEY_SEVEN: return Raylib_cs.KeyboardKey.KEY_SEVEN;
            case KeyboardKey.KEY_EIGHT: return Raylib_cs.KeyboardKey.KEY_EIGHT;
            case KeyboardKey.KEY_NINE: return Raylib_cs.KeyboardKey.KEY_NINE;
            case KeyboardKey.KEY_SEMICOLON: return Raylib_cs.KeyboardKey.KEY_SEMICOLON;
            case KeyboardKey.KEY_EQUAL: return Raylib_cs.KeyboardKey.KEY_EQUAL;
            case KeyboardKey.KEY_A: return Raylib_cs.KeyboardKey.KEY_A;
            case KeyboardKey.KEY_B: return Raylib_cs.KeyboardKey.KEY_B;
            case KeyboardKey.KEY_C: return Raylib_cs.KeyboardKey.KEY_C;
            case KeyboardKey.KEY_D: return Raylib_cs.KeyboardKey.KEY_D;
            case KeyboardKey.KEY_E: return Raylib_cs.KeyboardKey.KEY_E;
            case KeyboardKey.KEY_F: return Raylib_cs.KeyboardKey.KEY_F;
            case KeyboardKey.KEY_G: return Raylib_cs.KeyboardKey.KEY_G;
            case KeyboardKey.KEY_H: return Raylib_cs.KeyboardKey.KEY_H;
            case KeyboardKey.KEY_I: return Raylib_cs.KeyboardKey.KEY_I;
            case KeyboardKey.KEY_J: return Raylib_cs.KeyboardKey.KEY_J;
            case KeyboardKey.KEY_K: return Raylib_cs.KeyboardKey.KEY_K;
            case KeyboardKey.KEY_L: return Raylib_cs.KeyboardKey.KEY_L;
            case KeyboardKey.KEY_M: return Raylib_cs.KeyboardKey.KEY_M;
            case KeyboardKey.KEY_N: return Raylib_cs.KeyboardKey.KEY_N;
            case KeyboardKey.KEY_O: return Raylib_cs.KeyboardKey.KEY_O;
            case KeyboardKey.KEY_P: return Raylib_cs.KeyboardKey.KEY_P;
            case KeyboardKey.KEY_Q: return Raylib_cs.KeyboardKey.KEY_Q;
            case KeyboardKey.KEY_R: return Raylib_cs.KeyboardKey.KEY_R;
            case KeyboardKey.KEY_S: return Raylib_cs.KeyboardKey.KEY_S;
            case KeyboardKey.KEY_T: return Raylib_cs.KeyboardKey.KEY_T;
            case KeyboardKey.KEY_U: return Raylib_cs.KeyboardKey.KEY_U;
            case KeyboardKey.KEY_V: return Raylib_cs.KeyboardKey.KEY_V;
            case KeyboardKey.KEY_W: return Raylib_cs.KeyboardKey.KEY_W;
            case KeyboardKey.KEY_X: return Raylib_cs.KeyboardKey.KEY_X;
            case KeyboardKey.KEY_Y: return Raylib_cs.KeyboardKey.KEY_Y;
            case KeyboardKey.KEY_Z: return Raylib_cs.KeyboardKey.KEY_Z;
            case KeyboardKey.KEY_SPACE: return Raylib_cs.KeyboardKey.KEY_SPACE;
            case KeyboardKey.KEY_ESCAPE: return Raylib_cs.KeyboardKey.KEY_ESCAPE;
            case KeyboardKey.KEY_ENTER: return Raylib_cs.KeyboardKey.KEY_ENTER;
            case KeyboardKey.KEY_TAB: return Raylib_cs.KeyboardKey.KEY_TAB;
            case KeyboardKey.KEY_BACKSPACE: return Raylib_cs.KeyboardKey.KEY_BACKSPACE;
            case KeyboardKey.KEY_INSERT: return Raylib_cs.KeyboardKey.KEY_INSERT;
            case KeyboardKey.KEY_DELETE: return Raylib_cs.KeyboardKey.KEY_DELETE;
            case KeyboardKey.KEY_RIGHT: return Raylib_cs.KeyboardKey.KEY_RIGHT;
            case KeyboardKey.KEY_LEFT: return Raylib_cs.KeyboardKey.KEY_LEFT;
            case KeyboardKey.KEY_DOWN: return Raylib_cs.KeyboardKey.KEY_DOWN;
            case KeyboardKey.KEY_UP: return Raylib_cs.KeyboardKey.KEY_UP;
            case KeyboardKey.KEY_PAGE_UP: return Raylib_cs.KeyboardKey.KEY_PAGE_UP;
            case KeyboardKey.KEY_PAGE_DOWN: return Raylib_cs.KeyboardKey.KEY_PAGE_DOWN;
            case KeyboardKey.KEY_HOME: return Raylib_cs.KeyboardKey.KEY_HOME;
            case KeyboardKey.KEY_END: return Raylib_cs.KeyboardKey.KEY_END;
            case KeyboardKey.KEY_CAPS_LOCK: return Raylib_cs.KeyboardKey.KEY_CAPS_LOCK;
            case KeyboardKey.KEY_SCROLL_LOCK: return Raylib_cs.KeyboardKey.KEY_SCROLL_LOCK;
            case KeyboardKey.KEY_NUM_LOCK: return Raylib_cs.KeyboardKey.KEY_NUM_LOCK;
            case KeyboardKey.KEY_PRINT_SCREEN: return Raylib_cs.KeyboardKey.KEY_PRINT_SCREEN;
            case KeyboardKey.KEY_PAUSE: return Raylib_cs.KeyboardKey.KEY_PAUSE;
            case KeyboardKey.KEY_F1: return Raylib_cs.KeyboardKey.KEY_F1;
            case KeyboardKey.KEY_F2: return Raylib_cs.KeyboardKey.KEY_F2;
            case KeyboardKey.KEY_F3: return Raylib_cs.KeyboardKey.KEY_F3;
            case KeyboardKey.KEY_F4: return Raylib_cs.KeyboardKey.KEY_F4;
            case KeyboardKey.KEY_F5: return Raylib_cs.KeyboardKey.KEY_F5;
            case KeyboardKey.KEY_F6: return Raylib_cs.KeyboardKey.KEY_F6;
            case KeyboardKey.KEY_F7: return Raylib_cs.KeyboardKey.KEY_F7;
            case KeyboardKey.KEY_F8: return Raylib_cs.KeyboardKey.KEY_F8;
            case KeyboardKey.KEY_F9: return Raylib_cs.KeyboardKey.KEY_F9;
            case KeyboardKey.KEY_F10: return Raylib_cs.KeyboardKey.KEY_F10;
            case KeyboardKey.KEY_F11: return Raylib_cs.KeyboardKey.KEY_F11;
            case KeyboardKey.KEY_F12: return Raylib_cs.KeyboardKey.KEY_F12;
            case KeyboardKey.KEY_LEFT_SHIFT: return Raylib_cs.KeyboardKey.KEY_LEFT_SHIFT;
            case KeyboardKey.KEY_LEFT_CONTROL: return Raylib_cs.KeyboardKey.KEY_LEFT_CONTROL;
            case KeyboardKey.KEY_LEFT_ALT: return Raylib_cs.KeyboardKey.KEY_LEFT_ALT;
            case KeyboardKey.KEY_LEFT_SUPER: return Raylib_cs.KeyboardKey.KEY_LEFT_SUPER;
            case KeyboardKey.KEY_RIGHT_SHIFT: return Raylib_cs.KeyboardKey.KEY_RIGHT_SHIFT;
            case KeyboardKey.KEY_RIGHT_CONTROL: return Raylib_cs.KeyboardKey.KEY_RIGHT_CONTROL;
            case KeyboardKey.KEY_RIGHT_ALT: return Raylib_cs.KeyboardKey.KEY_RIGHT_ALT;
            case KeyboardKey.KEY_RIGHT_SUPER: return Raylib_cs.KeyboardKey.KEY_RIGHT_SUPER;
            case KeyboardKey.KEY_KB_MENU: return Raylib_cs.KeyboardKey.KEY_KB_MENU;
            case KeyboardKey.KEY_LEFT_BRACKET: return Raylib_cs.KeyboardKey.KEY_LEFT_BRACKET;
            case KeyboardKey.KEY_BACKSLASH: return Raylib_cs.KeyboardKey.KEY_BACKSLASH;
            case KeyboardKey.KEY_RIGHT_BRACKET: return Raylib_cs.KeyboardKey.KEY_RIGHT_BRACKET;
            case KeyboardKey.KEY_GRAVE: return Raylib_cs.KeyboardKey.KEY_GRAVE;
            case KeyboardKey.KEY_KP_0: return Raylib_cs.KeyboardKey.KEY_KP_0;
            case KeyboardKey.KEY_KP_1: return Raylib_cs.KeyboardKey.KEY_KP_1;
            case KeyboardKey.KEY_KP_2: return Raylib_cs.KeyboardKey.KEY_KP_2;
            case KeyboardKey.KEY_KP_3: return Raylib_cs.KeyboardKey.KEY_KP_3;
            case KeyboardKey.KEY_KP_4: return Raylib_cs.KeyboardKey.KEY_KP_4;
            case KeyboardKey.KEY_KP_5: return Raylib_cs.KeyboardKey.KEY_KP_5;
            case KeyboardKey.KEY_KP_6: return Raylib_cs.KeyboardKey.KEY_KP_6;
            case KeyboardKey.KEY_KP_7: return Raylib_cs.KeyboardKey.KEY_KP_7;
            case KeyboardKey.KEY_KP_8: return Raylib_cs.KeyboardKey.KEY_KP_8;
            case KeyboardKey.KEY_KP_9: return Raylib_cs.KeyboardKey.KEY_KP_9;
            case KeyboardKey.KEY_KP_DECIMAL: return Raylib_cs.KeyboardKey.KEY_KP_DECIMAL;
            case KeyboardKey.KEY_KP_DIVIDE: return Raylib_cs.KeyboardKey.KEY_KP_DIVIDE;
            case KeyboardKey.KEY_KP_MULTIPLY: return Raylib_cs.KeyboardKey.KEY_KP_MULTIPLY;
            case KeyboardKey.KEY_KP_SUBTRACT: return Raylib_cs.KeyboardKey.KEY_KP_SUBTRACT;
            case KeyboardKey.KEY_KP_ADD: return Raylib_cs.KeyboardKey.KEY_KP_ADD;
            case KeyboardKey.KEY_KP_ENTER: return Raylib_cs.KeyboardKey.KEY_KP_ENTER;
            case KeyboardKey.KEY_KP_EQUAL: return Raylib_cs.KeyboardKey.KEY_KP_EQUAL;
            default:
                return Raylib_cs.KeyboardKey.KEY_NULL;
        }

    }
}
