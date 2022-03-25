using Microsoft.Extensions.DependencyInjection;
using SampSharp.Core;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

new GameModeBuilder()
    .UseEcs<Startup>()
    .Run();

public class Startup : IStartup
{
    public void Configure(IServiceCollection services)
    {
        services.AddSystemsInAssembly();
    }

    public void Configure(IEcsBuilder builder)
    {
        builder.EnableSampEvents();
    }
}

public class HelloWorldSystem : ISystem
{
    [Event]
    public void OnGameModeInit(IServerService server)
    {
        Console.WriteLine("Hello, World!");

        server.SetGameModeText("Hello World!");
    }

    [Event]
    public void OnPlayerConnect(Player player)
    {
        player.SendClientMessage($"Hello, {player.Name}!");
    }
}