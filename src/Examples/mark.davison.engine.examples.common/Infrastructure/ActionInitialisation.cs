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
    }
}
