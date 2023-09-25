namespace mark.davison.engine.input.abstractions.Utilities;

public enum InputActivationType
{
    KeyPress,
    KeyHold,
    MouseButtonPress,
    MouseButtonHold,
    None
}

public class InputAction
{
    public InputActivationType Primary { get; set; } = InputActivationType.None;
    public KeyboardKey PrimaryKey { get; set; } = KeyboardKey.NULL;
    public MouseButton PrimaryButton { get; set; } = MouseButton.MOUSE_BUTTON_NULL;

    public InputActivationType Secondary { get; set; } = InputActivationType.None;
    public KeyboardKey SecondaryKey { get; set; } = KeyboardKey.NULL;
    public MouseButton SecondaryButton { get; set; } = MouseButton.MOUSE_BUTTON_NULL;

    public bool ModifierControl { get; set; }
    public bool ModifierAlt { get; set; }
    public bool ModifierShift { get; set; }
}