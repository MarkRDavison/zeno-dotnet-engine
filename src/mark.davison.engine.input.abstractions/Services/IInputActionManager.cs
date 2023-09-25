namespace mark.davison.engine.input.abstractions.Services;

public interface IInputActionManager
{
    void RegisterAction(string name, InputAction action);
    bool IsActionInvoked(string name);
}
