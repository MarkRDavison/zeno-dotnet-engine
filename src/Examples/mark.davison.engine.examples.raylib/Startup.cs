namespace mark.davison.engine.examples.raylib;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var configured = Configuration.GetSection(ApplicationConfiguration.Section);
        services.Configure<ApplicationConfiguration>(configured);
        services
            .UseGame<RaylibApplication>(typeof(Startup), typeof(Scenes))
            .UseECS(typeof(Startup), typeof(Scenes));
        services.AddHostedService<ApplicationHostedService>();
        services.UseRaylibBackend();
        services.AddTransient<IApplicationInitialisation, ExampleApplicationInitialisation>();
    }
}
