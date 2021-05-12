using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Linq;
using Pyan.Services;
using System;

namespace Pyan.Modules
{
    public class InformationModule : ModuleBase<SocketCommandContext>
    {

        [Command("Info")]
        public async Task Info(SocketGuildUser user = null)
        {
            user ??= (SocketGuildUser)Context.User;
            var builder = new EmbedBuilder()
                .WithTitle(":information_source: **Information Box**")
                .WithDescription($"Find some information about {user.Mention}")
                .AddField("<:KannaSip:838739588573823038> Nickname", user.Username)
                .AddField("<:KannaSip:838739588573823038> User ID", user.Id)
                .AddField("<:KannaSip:838739588573823038> Current server", user.Guild)
                .AddField("<:KannaSip:838739588573823038> Current Status", user.Status)
                .AddField("<:KannaSip:838739588573823038> Created at", user.CreatedAt.ToString("dd MMMM yyyy zzz"), true)
                .AddField("<:KannaSip:838739588573823038> Joined at", user.JoinedAt.Value.ToString("dd MMMM yyyy"), true)
                .AddField("<:KannaSip:838739588573823038> Roles", string.Join(" ", user.Roles.Select(x => x.Mention)))
                .AddField($"<:KannaSip:838739588573823038> {user.Username}'s avatar", $":paperclip: [link to the avatar picture]({user.GetAvatarUrl()}) ")
                .WithImageUrl(user.GetAvatarUrl())
                .WithColor(new Color(255, 166, 207))
                .WithCurrentTimestamp();
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
