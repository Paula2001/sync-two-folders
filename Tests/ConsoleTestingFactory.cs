using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Spectre.Console;
using Spectre.Console.Testing;

namespace sync.Tests.Integration;

public sealed class ConsoleTestingFactory : IAsyncLifetime
{
    public readonly CancellationTokenSource _cts;

    public string TempRoot { get; } = "data";
    public string SourceDir { get; } = "source";
    public string TargetDir { get; } = "target";
    public string LogFileName { get; } = "log";
    public ServiceProvider Services { get; }
    public TestConsole Console {get;set;}

    public ConsoleTestingFactory()
    {
        _cts = new CancellationTokenSource();

        TempRoot = Path.Combine(Path.GetTempPath(), $"sync-it-{Guid.NewGuid():N}");
        SourceDir = Path.Combine(TempRoot, "source");
        TargetDir = Path.Combine(TempRoot, "target");
        LogFileName = $"logs-{Guid.NewGuid():N}";

        Directory.CreateDirectory(SourceDir);
        Directory.CreateDirectory(TargetDir);

        Services = Bootstrap.BuildServiceProvider(
            _cts,
            config =>
            {
                config.SourceFolder = SourceDir;
                config.TargetFolder = TargetDir;
                config.TimeIntervalInSeconds = 1;
                config.LogFilePath = LogFileName;

            },
            validate: true, services =>
            {
                Console = new TestConsole();
                
                Console.Profile.Capabilities.Interactive = true;
                Console.Profile.Capabilities.Ansi = true;
                
                services.RemoveAll<IAnsiConsole>();
                services.AddSingleton<IAnsiConsole>(Console);
            });

    
    }

    public async Task InitializeAsync()
    {
        // var app = Services.GetRequiredService<Application>();
        // await app.Run();
    }

    public Task DisposeAsync()
    {
        Services.Dispose();
        _cts.Dispose();

        if (Directory.Exists(TempRoot))
        {
            Directory.Delete(TempRoot, recursive: true);
        }
        return Task.CompletedTask;
    }
}
