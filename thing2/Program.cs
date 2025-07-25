using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace thing2;

class Program
{
    private static Dictionary<ulong, Player> userData = new();

    //userData[Context.userData.Id].balanace-= 10;
    private const ulong guild = 1396851978801516564;
    private static InteractionService _interactions;
    private static DiscordSocketClient client;

    private static Task Log(LogMessage msg)
    {
        LogManual(msg.ToString(), msg.Severity);
        return Task.CompletedTask;
    }

    private static void LogManual(string text, LogSeverity severity)
    {
        Console.ForegroundColor = ChooseColorForSeverity(severity);
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static ConsoleColor ChooseColorForSeverity(LogSeverity severity)
    {
        return severity switch
        {
            LogSeverity.Critical => ConsoleColor.Cyan,
            LogSeverity.Error => ConsoleColor.Red,
            LogSeverity.Warning => ConsoleColor.Yellow,
            LogSeverity.Debug => ConsoleColor.Green,
            _ => ConsoleColor.White
        };
    }

    private static async Task Ready()
    {
        Console.WriteLine("The Bot is ready!");
        client.Ready += Ready;
        await _interactions.AddModuleAsync<SlashCommandExamples>(null);
        await _interactions.RegisterCommandsToGuildAsync(guild);
    }

    public static async Task Main(string[] args)
    {
        client = new DiscordSocketClient();
        _interactions = new InteractionService(client);
        client.Log += Log;
        client.Ready += Ready;
        client.InteractionCreated += HandleInteraction;
        string token = await File.ReadAllTextAsync("token.txt");
        await client.LoginAsync(TokenType.Bot,
            token);
        await client.StartAsync();
        await Task.Delay(-1); 
    }

    private static async Task HandleInteraction(SocketInteraction interaction)
    {
        var context = new SocketInteractionContext(client, interaction);
        await _interactions.ExecuteCommandAsync(context, null);
    }

    public static Player GetOrCreatePlayer(ulong id)
    {
        Player player;
        if (!userData.TryGetValue(id,out player))
        {
            player = new Player();
            userData.Add(id, player);
            Console.WriteLine("Created new player with ID:" + id);
        }
        return player;
    }

}