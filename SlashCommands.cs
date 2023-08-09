using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace Pomodoro
{
    public class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("start", "Inicia una sesión de estudio")]
        public async Task StartCommand(
            InteractionContext ctx,
            [Option("estudio", "Minutos de estudio")] long workMinutes,
            [Option("descanso", "Minutos de descanso")] long breakMinutes
            )
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Sesión de estudio iniciada! {Formatter.Emoji(DiscordEmoji.FromGuildEmote(ctx.Client, (long)Emotes.PepeReading))}"));

            for (int i = 0; i < 4; i++)
            {
                await Task.Delay((int)workMinutes * 60000);
                await ctx.Channel.SendMessageAsync($"{Formatter.Emoji(DiscordEmoji.FromGuildEmote(ctx.Client, (long)Emotes.PepeStop))} Descanso de {breakMinutes} minutos! {Formatter.Mention(ctx.User, true)}");
                await Task.Delay((int)breakMinutes * 60000);
                await ctx.Channel.SendMessageAsync($"{Formatter.Mention(ctx.User, true)} Fin del descanso! Progreso: {i + 1}/4");
            }
            await ctx.Channel.SendMessageAsync($"{Formatter.Mention(ctx.User, true)} Sesión de estudio finalizada! {Formatter.Emoji(DiscordEmoji.FromGuildEmote(ctx.Client, (long)Emotes.Gladge))}");
        }
    }
}
