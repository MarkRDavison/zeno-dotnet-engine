namespace mark.davison.engine.core.abstractions.Infrastructure;

public interface IApplicationInitialisation
{
    void InitialiseInputActions(IServiceProvider provider);
    void InitialiseResources(IServiceProvider provider);
}
