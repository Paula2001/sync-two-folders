using ColorLoggerLibrary;
using Microsoft.Extensions.DependencyInjection;
using sync.src.Commands;
using sync.DataManagement;

namespace sync.src;
class Program
{

    static void Main()
    {
        ServiceCollection services = new();

        services.AddSingleton<LoadConfigCommand>();
        services.AddSingleton<SetSourceFolderCommand>();
        services.AddSingleton<CancellationTokenSource>();
        services.AddSingleton<CommandsHandler>();
        services.AddSingleton<Config>();
        services.AddSingleton<FolderSync>();
        services.AddSingleton<ColorLogger>();
        services.AddSingleton<Application>();

        // Build the provider
        var provider = services.BuildServiceProvider();

        // Run the app
        var app = provider.GetRequiredService<Application>();
        app.Run();
    }

}


