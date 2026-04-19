using Microsoft.Extensions.DependencyInjection;

namespace sync;
class Program
{

    static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        using var provider = Bootstrap.BuildServiceProvider(cts);

        // Run the app
        var app = provider.GetRequiredService<Application>();
        try
        {
            await app.Run();
        }
        catch (OperationCanceledException) { }
        finally
        {
            Environment.Exit(0);
        }
    }

}


