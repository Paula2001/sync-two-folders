using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Testing;
using sync.Helpers.Integration;

namespace sync.Tests.Integration;

public class LoadConfigOptionOutputTests(ConsoleTestingFactory serviceProvider) : IClassFixture<ConsoleTestingFactory>
{
    [Fact]
    public async Task Execute_Prints_Current_Configuration_Using_Spectre_Console()
    {
        
        serviceProvider.Console.Interactive();

        var app = serviceProvider.Services.GetRequiredService<Application>();
        var config = serviceProvider.Services.GetRequiredService<Config>();

        InputHelpers.SelectConfig(serviceProvider.Console);

        InputHelpers.QuitResult(serviceProvider.Console);

        InputHelpers.QuitApp(serviceProvider.Console);

        var appTask = app.Run();

        await Task.WhenAny(appTask, Task.Delay(2000)); // this is a quick fix until make the app really testable
        
        var output = serviceProvider.Console.Output.ReplaceLineEndings("");
        
        Assert.Contains($"Source: {config.SourceFolder}", output);
        Assert.Contains($"Target: {config.TargetFolder}", output);
        Assert.Contains($"Interval: {config.TimeIntervalInSeconds}s", output);
        Assert.Contains($"Log Path: {config.LogFilePath}", output);
    }
}
