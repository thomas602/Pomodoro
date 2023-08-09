using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace Pomodoro
{
    public class Pomodoro
    {
        public static async Task Main(string[] args)
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Environment.GetEnvironmentVariable("TOKEN"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });

            var slash = discord.UseSlashCommands();
            slash.RegisterCommands<SlashCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}