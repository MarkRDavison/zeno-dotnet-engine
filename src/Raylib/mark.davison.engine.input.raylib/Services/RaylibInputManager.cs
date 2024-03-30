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
            case MouseButton.MOUSE_BUTTON_LEFT: return Raylib_cs.MouseButton.Left;
            case MouseButton.MOUSE_BUTTON_RIGHT: return Raylib_cs.MouseButton.Right;
            case MouseButton.MOUSE_BUTTON_MIDDLE: return Raylib_cs.MouseButton.Middle;
            case MouseButton.MOUSE_BUTTON_SIDE: return Raylib_cs.MouseButton.Side;
            case MouseButton.MOUSE_BUTTON_EXTRA: return Raylib_cs.MouseButton.Extra;
            case MouseButton.MOUSE_BUTTON_FORWARD: return Raylib_cs.MouseButton.Forward;
            case MouseButton.MOUSE_BUTTON_BACK: return Raylib_cs.MouseButton.Back;
            default:
                return (Raylib_cs.MouseButton)(-1);
        }

    }

    private static Raylib_cs.KeyboardKey ToRaylib(KeyboardKey key)
    {
        switch (key)
        {
            case KeyboardKey.KEY_APOSTROPHE: return Raylib_cs.KeyboardKey.Apostrophe;
            case KeyboardKey.KEY_COMMA: return Raylib_cs.KeyboardKey.Comma;
            case KeyboardKey.KEY_MINUS: return Raylib_cs.KeyboardKey.Minus;
            case KeyboardKey.KEY_PERIOD: return Raylib_cs.KeyboardKey.Period;
            case KeyboardKey.KEY_SLASH: return Raylib_cs.KeyboardKey.Slash;
            case KeyboardKey.KEY_ZERO: return Raylib_cs.KeyboardKey.Zero;
            case KeyboardKey.KEY_ONE: return Raylib_cs.KeyboardKey.One;
            case KeyboardKey.KEY_TWO: return Raylib_cs.KeyboardKey.Two;
            case KeyboardKey.KEY_THREE: return Raylib_cs.KeyboardKey.Three;
            case KeyboardKey.KEY_FOUR: return Raylib_cs.KeyboardKey.Four;
            case KeyboardKey.KEY_FIVE: return Raylib_cs.KeyboardKey.Five;
            case KeyboardKey.KEY_SIX: return Raylib_cs.KeyboardKey.Six;
            case KeyboardKey.KEY_SEVEN: return Raylib_cs.KeyboardKey.Seven;
            case KeyboardKey.KEY_EIGHT: return Raylib_cs.KeyboardKey.Eight;
            case KeyboardKey.KEY_NINE: return Raylib_cs.KeyboardKey.Nine;
            case KeyboardKey.KEY_SEMICOLON: return Raylib_cs.KeyboardKey.Semicolon;
            case KeyboardKey.KEY_EQUAL: return Raylib_cs.KeyboardKey.Equal;
            case KeyboardKey.KEY_A: return Raylib_cs.KeyboardKey.A;
            case KeyboardKey.KEY_B: return Raylib_cs.KeyboardKey.B;
            case KeyboardKey.KEY_C: return Raylib_cs.KeyboardKey.C;
            case KeyboardKey.KEY_D: return Raylib_cs.KeyboardKey.D;
            case KeyboardKey.KEY_E: return Raylib_cs.KeyboardKey.E;
            case KeyboardKey.KEY_F: return Raylib_cs.KeyboardKey.F;
            case KeyboardKey.KEY_G: return Raylib_cs.KeyboardKey.G;
            case KeyboardKey.KEY_H: return Raylib_cs.KeyboardKey.H;
            case KeyboardKey.KEY_I: return Raylib_cs.KeyboardKey.I;
            case KeyboardKey.KEY_J: return Raylib_cs.KeyboardKey.J;
            case KeyboardKey.KEY_K: return Raylib_cs.KeyboardKey.K;
            case KeyboardKey.KEY_L: return Raylib_cs.KeyboardKey.L;
            case KeyboardKey.KEY_M: return Raylib_cs.KeyboardKey.M;
            case KeyboardKey.KEY_N: return Raylib_cs.KeyboardKey.N;
            case KeyboardKey.KEY_O: return Raylib_cs.KeyboardKey.O;
            case KeyboardKey.KEY_P: return Raylib_cs.KeyboardKey.P;
            case KeyboardKey.KEY_Q: return Raylib_cs.KeyboardKey.Q;
            case KeyboardKey.KEY_R: return Raylib_cs.KeyboardKey.R;
            case KeyboardKey.KEY_S: return Raylib_cs.KeyboardKey.S;
            case KeyboardKey.KEY_T: return Raylib_cs.KeyboardKey.T;
            case KeyboardKey.KEY_U: return Raylib_cs.KeyboardKey.U;
            case KeyboardKey.KEY_V: return Raylib_cs.KeyboardKey.V;
            case KeyboardKey.KEY_W: return Raylib_cs.KeyboardKey.W;
            case KeyboardKey.KEY_X: return Raylib_cs.KeyboardKey.X;
            case KeyboardKey.KEY_Y: return Raylib_cs.KeyboardKey.Y;
            case KeyboardKey.KEY_Z: return Raylib_cs.KeyboardKey.Z;
            case KeyboardKey.KEY_SPACE: return Raylib_cs.KeyboardKey.Space;
            case KeyboardKey.KEY_ESCAPE: return Raylib_cs.KeyboardKey.Escape;
            case KeyboardKey.KEY_ENTER: return Raylib_cs.KeyboardKey.Enter;
            case KeyboardKey.KEY_TAB: return Raylib_cs.KeyboardKey.Tab;
            case KeyboardKey.KEY_BACKSPACE: return Raylib_cs.KeyboardKey.Backspace;
            case KeyboardKey.KEY_INSERT: return Raylib_cs.KeyboardKey.Insert;
            case KeyboardKey.KEY_DELETE: return Raylib_cs.KeyboardKey.Delete;
            case KeyboardKey.KEY_RIGHT: return Raylib_cs.KeyboardKey.Right;
            case KeyboardKey.KEY_LEFT: return Raylib_cs.KeyboardKey.Left;
            case KeyboardKey.KEY_DOWN: return Raylib_cs.KeyboardKey.Down;
            case KeyboardKey.KEY_UP: return Raylib_cs.KeyboardKey.Up;
            case KeyboardKey.KEY_PAGE_UP: return Raylib_cs.KeyboardKey.PageUp;
            case KeyboardKey.KEY_PAGE_DOWN: return Raylib_cs.KeyboardKey.PageDown;
            case KeyboardKey.KEY_HOME: return Raylib_cs.KeyboardKey.Home;
            case KeyboardKey.KEY_END: return Raylib_cs.KeyboardKey.End;
            case KeyboardKey.KEY_CAPS_LOCK: return Raylib_cs.KeyboardKey.CapsLock;
            case KeyboardKey.KEY_SCROLL_LOCK: return Raylib_cs.KeyboardKey.ScrollLock;
            case KeyboardKey.KEY_NUM_LOCK: return Raylib_cs.KeyboardKey.NumLock;
            case KeyboardKey.KEY_PRINT_SCREEN: return Raylib_cs.KeyboardKey.PrintScreen;
            case KeyboardKey.KEY_PAUSE: return Raylib_cs.KeyboardKey.Pause;
            case KeyboardKey.KEY_F1: return Raylib_cs.KeyboardKey.F1;
            case KeyboardKey.KEY_F2: return Raylib_cs.KeyboardKey.F2;
            case KeyboardKey.KEY_F3: return Raylib_cs.KeyboardKey.F3;
            case KeyboardKey.KEY_F4: return Raylib_cs.KeyboardKey.F4;
            case KeyboardKey.KEY_F5: return Raylib_cs.KeyboardKey.F5;
            case KeyboardKey.KEY_F6: return Raylib_cs.KeyboardKey.F6;
            case KeyboardKey.KEY_F7: return Raylib_cs.KeyboardKey.F7;
            case KeyboardKey.KEY_F8: return Raylib_cs.KeyboardKey.F8;
            case KeyboardKey.KEY_F9: return Raylib_cs.KeyboardKey.F9;
            case KeyboardKey.KEY_F10: return Raylib_cs.KeyboardKey.F10;
            case KeyboardKey.KEY_F11: return Raylib_cs.KeyboardKey.F11;
            case KeyboardKey.KEY_F12: return Raylib_cs.KeyboardKey.F12;
            case KeyboardKey.KEY_LEFT_SHIFT: return Raylib_cs.KeyboardKey.LeftShift;
            case KeyboardKey.KEY_LEFT_CONTROL: return Raylib_cs.KeyboardKey.LeftControl;
            case KeyboardKey.KEY_LEFT_ALT: return Raylib_cs.KeyboardKey.LeftAlt;
            case KeyboardKey.KEY_LEFT_SUPER: return Raylib_cs.KeyboardKey.LeftSuper;
            case KeyboardKey.KEY_RIGHT_SHIFT: return Raylib_cs.KeyboardKey.RightShift;
            case KeyboardKey.KEY_RIGHT_CONTROL: return Raylib_cs.KeyboardKey.RightControl;
            case KeyboardKey.KEY_RIGHT_ALT: return Raylib_cs.KeyboardKey.RightAlt;
            case KeyboardKey.KEY_RIGHT_SUPER: return Raylib_cs.KeyboardKey.RightSuper;
            case KeyboardKey.KEY_KB_MENU: return Raylib_cs.KeyboardKey.KeyboardMenu;
            case KeyboardKey.KEY_LEFT_BRACKET: return Raylib_cs.KeyboardKey.LeftBracket;
            case KeyboardKey.KEY_BACKSLASH: return Raylib_cs.KeyboardKey.Backslash;
            case KeyboardKey.KEY_RIGHT_BRACKET: return Raylib_cs.KeyboardKey.RightBracket;
            case KeyboardKey.KEY_GRAVE: return Raylib_cs.KeyboardKey.Grave;
            case KeyboardKey.KEY_KP_0: return Raylib_cs.KeyboardKey.Kp0;
            case KeyboardKey.KEY_KP_1: return Raylib_cs.KeyboardKey.Kp1;
            case KeyboardKey.KEY_KP_2: return Raylib_cs.KeyboardKey.Kp2;
            case KeyboardKey.KEY_KP_3: return Raylib_cs.KeyboardKey.Kp3;
            case KeyboardKey.KEY_KP_4: return Raylib_cs.KeyboardKey.Kp4;
            case KeyboardKey.KEY_KP_5: return Raylib_cs.KeyboardKey.Kp5;
            case KeyboardKey.KEY_KP_6: return Raylib_cs.KeyboardKey.Kp6;
            case KeyboardKey.KEY_KP_7: return Raylib_cs.KeyboardKey.Kp7;
            case KeyboardKey.KEY_KP_8: return Raylib_cs.KeyboardKey.Kp8;
            case KeyboardKey.KEY_KP_9: return Raylib_cs.KeyboardKey.Kp9;
            case KeyboardKey.KEY_KP_DECIMAL: return Raylib_cs.KeyboardKey.KpDecimal;
            case KeyboardKey.KEY_KP_DIVIDE: return Raylib_cs.KeyboardKey.KpDivide;
            case KeyboardKey.KEY_KP_MULTIPLY: return Raylib_cs.KeyboardKey.KpMultiply;
            case KeyboardKey.KEY_KP_SUBTRACT: return Raylib_cs.KeyboardKey.KpSubtract;
            case KeyboardKey.KEY_KP_ADD: return Raylib_cs.KeyboardKey.KpAdd;
            case KeyboardKey.KEY_KP_ENTER: return Raylib_cs.KeyboardKey.KpEnter;
            case KeyboardKey.KEY_KP_EQUAL: return Raylib_cs.KeyboardKey.KpEqual;
            default:
                return Raylib_cs.KeyboardKey.Null;
        }

    }
}
