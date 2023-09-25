namespace mark.davison.engine.game.Services;

public class InputActionManager : IInputActionManager
{
    private readonly IDictionary<string, InputAction> _actions;
    private readonly IInputManager _inputManager;

    public InputActionManager(IInputManager inputManager)
    {
        _actions = new Dictionary<string, InputAction>();
        _inputManager = inputManager;
    }

    public void RegisterAction(string name, InputAction action)
    {
        _actions[name] = action;
    }

    public bool IsActionInvoked(string name)
    {
        if (_actions.TryGetValue(name, out var action))
        {
            return IsActionInvoked(action);
        }

        return false;
    }

    protected bool IsActionInvoked(InputAction action)
    {
        if (action.Primary == InputActivationType.KeyHold ||
            action.Primary == InputActivationType.KeyPress)
        {
            if (_inputManager.IsKeyDown(action.PrimaryKey) &&
                (!action.ModifierControl || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_CONTROL)) &&
                (!action.ModifierShift || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)) &&
                (!action.ModifierAlt || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
            {
                if (action.Primary == InputActivationType.KeyPress)
                {
                    return _inputManager.IsKeyPressed(action.PrimaryKey);
                }

                return true;
            }
        }

        if (action.Primary == InputActivationType.MouseButtonHold ||
            action.Primary == InputActivationType.MouseButtonPress)
        {
            if (_inputManager.IsMouseButtonDown(action.PrimaryButton) &&
                (!action.ModifierControl || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_CONTROL)) &&
                (!action.ModifierShift || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)) &&
                (!action.ModifierAlt || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
            {
                if (action.Primary == InputActivationType.MouseButtonPress)
                {
                    return _inputManager.IsMouseButtonPressed(action.PrimaryButton);
                }

                return true;
            }
        }

        if (action.Secondary == InputActivationType.KeyHold ||
            action.Secondary == InputActivationType.KeyPress)
        {
            if (_inputManager.IsKeyDown(action.SecondaryKey) &&
                (!action.ModifierControl || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_CONTROL)) &&
                (!action.ModifierShift || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)) &&
                (!action.ModifierAlt || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
            {
                if (action.Secondary == InputActivationType.KeyPress)
                {
                    return _inputManager.IsKeyPressed(action.SecondaryKey);
                }

                return true;
            }
        }

        if (action.Secondary == InputActivationType.MouseButtonHold ||
            action.Secondary == InputActivationType.MouseButtonPress)
        {
            if (_inputManager.IsMouseButtonDown(action.SecondaryButton) &&
                (!action.ModifierControl || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_CONTROL)) &&
                (!action.ModifierShift || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)) &&
                (!action.ModifierAlt || _inputManager.IsKeyDown(KeyboardKey.KEY_LEFT_ALT) || _inputManager.IsKeyDown(KeyboardKey.KEY_RIGHT_ALT)))
            {
                if (action.Secondary == InputActivationType.MouseButtonPress)
                {
                    return _inputManager.IsMouseButtonPressed(action.SecondaryButton);
                }

                return true;
            }
        }

        return false;
    }
}
