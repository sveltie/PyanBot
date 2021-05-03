using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyan.Modules
{
    public class RoleplayModule : ModuleBase<SocketCommandContext>
    {
        [Command("Pat")]
        [Summary("Pat + The user you want to pat")]
        public async Task Pat(string input)
        {
            var id = Context.Message.Author.Id;
            var builder = new EmbedBuilder()
                .WithTitle("(⁄ ⁄•⁄ω⁄•⁄ ⁄)")
                .WithDescription(Context.User.Mention + " pats " + input + " <:unnamed1:838731687755382824>")
                .WithImageUrl("https://i.pinimg.com/originals/95/2b/94/952b94cc7a9bfd9107e28ece64b158de.gif")
                .WithColor(new Color(255, 166, 207));
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("Kiss")]
        [Summary("Kiss + The user you want to pat")]
        public async Task Kiss(string input)
        {
            var id = Context.Message.Author.Id;
            var builder = new EmbedBuilder()
                .WithDescription(Context.User.Mention + " kisses " + input + "'s cheek")
                .WithImageUrl("https://i.pinimg.com/originals/f7/4e/3e/f74e3e62f52eefdee095d358bf3b6195.gif")
                .WithColor(new Color(255, 166, 207));
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("Hug")]
        [Summary("Hug + The user you want to pat")]
        public async Task Hug(string input)
        {
            var id = Context.Message.Author.Id;
            var builder = new EmbedBuilder()
                .WithDescription(Context.User.Mention + " hugs " + input)
                .WithImageUrl("https://acegif.com/wp-content/gif/anime-hug-12.gif")
                .WithColor(new Color(255, 166, 207));
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
