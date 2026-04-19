using ColorLoggerLibrary;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using sync.FolderManagement;
using sync.Logger;
using sync.Options;

namespace sync;

public static class Bootstrap
{
    public static ServiceProvider BuildServiceProvider(
        CancellationTokenSource? cts = null,
        Action<Config>? configureConfig = null,
        bool validate = true,
        Action<IServiceCollection>? configureServices = null)
    {
        cts ??= new CancellationTokenSource();
        ServiceCollection services = new();

        typeof(OptionBase).Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(OptionBase)) && !t.IsAbstract)
            .ToList()
            .ForEach(t => services.AddSingleton(t));

        services.AddSingleton(cts);
        services.AddSingleton<OptionsHandler>();
        services.AddSingleton<Config>();
        services.AddSingleton<FileLogger>();
        services.AddSingleton(AnsiConsole.Console);
        services.AddSingleton<FolderSync>();
        services.AddSingleton<ColorLogger>();
        services.AddSingleton<Application>();

        configureServices?.Invoke(services);

        var provider = services.BuildServiceProvider(new ServiceProviderOptions
        {
            ValidateOnBuild = validate,
            ValidateScopes = validate
        });

        if (configureConfig is not null)
        {
            var config = provider.GetRequiredService<Config>();
            configureConfig(config);
        }

        return provider;
    }
}