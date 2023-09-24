﻿namespace mark.davison.engine.examples.raylib;

internal class Program
{
    static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).Build().RunAsync();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .ConfigureLogging(_ =>
            {

            })
            .ConfigureAppConfiguration(_ =>
            {
                _.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _.AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true);
                _.AddEnvironmentVariables();
            });
}
