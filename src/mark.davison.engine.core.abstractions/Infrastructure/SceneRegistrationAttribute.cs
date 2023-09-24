namespace mark.davison.engine.core.abstractions.Infrastructure;

public class SceneRegistrationAttribute : Attribute
{
    public required string Name { get; set; }
}
