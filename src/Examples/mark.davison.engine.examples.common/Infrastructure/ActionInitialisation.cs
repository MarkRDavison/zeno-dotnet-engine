namespace mark.davison.engine.examples.common.Infrastructure;

public static class ActionInitialisation
{
    public static void RegisterActions(IInputActionManager inputActionManager)
    {
        inputActionManager.RegisterAction("LEFT_CLICK", new InputAction
        {
            Primary = InputActivationType.MouseButtonPress,
            PrimaryButton = MouseButton.MOUSE_BUTTON_LEFT
        });
        inputActionManager.RegisterAction("THRUST", new InputAction
        {
            Primary = InputActivationType.KeyHold,
            PrimaryKey = KeyboardKey.KEY_W
        });
        inputActionManager.RegisterAction("ROTATE_CW", new InputAction
        {
            Primary = InputActivationType.KeyHold,
            PrimaryKey = KeyboardKey.KEY_D
        });
        inputActionManager.RegisterAction("ROTATE_CCW", new InputAction
        {
            Primary = InputActivationType.KeyHold,
            PrimaryKey = KeyboardKey.KEY_A
        });
    }
}
