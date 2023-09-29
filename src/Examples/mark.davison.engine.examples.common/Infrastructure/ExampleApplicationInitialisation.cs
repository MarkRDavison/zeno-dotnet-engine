namespace mark.davison.engine.examples.common.Infrastructure;

public class ExampleApplicationInitialisation : IApplicationInitialisation
{
    public void InitialiseInputActions(IServiceProvider provider)
    {
        ActionInitialisation.RegisterActions(provider.GetRequiredService<IInputActionManager>());
    }

    public void InitialiseResources(IServiceProvider provider)
    {
        ResourceInitialisation.InitResources(provider);
    }
}
