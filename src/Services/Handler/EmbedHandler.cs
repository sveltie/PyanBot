using Discord;
using Discord.WebSocket;
using Pyan.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Victoria;

namespace Pyan.Handlers
{
    public static class EmbedHandler
    {
        public static async Task<Embed> CreateBasicEmbed(string title, string description, Color color) ///ANOTHER CHAOSS
        {
            var embed = await Task.Run(() => (new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(color)
                .WithThumbnailUrl("https://s3.us-east-2.amazonaws.com/stickers-for-discord/menhera-1538986577173-wink.png")
                .WithCurrentTimestamp().Build()));
            return embed;
        }

        public static async Task<Embed> CreateBasicEmbed2(string title, string description, Color color) ///ThumbnailUrl Variation 2
        {
            var embed = await Task.Run(() => (new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(color)
                .WithThumbnailUrl("https://s3.us-east-2.amazonaws.com/stickers-for-discord/menhera-1538993266659-blush.png")
                .WithCurrentTimestamp().Build()));
            return embed;
        }

        public static async Task<Embed> CreateBasicEmbed3(string title, string description, Color color) ///ThumbnailUrl Variation 3
        {
            var embed = await Task.Run(() => (new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(color)
                .WithThumbnailUrl("https://s3.us-east-2.amazonaws.com/stickers-for-discord/menhera-1538987951967-music.png")
                .WithCurrentTimestamp().Build()));
            return embed;
        }

        public static async Task<Embed> CreateBasicEmbed4(string title, string description, Color color) ///ThumbnailUrl Variation 4
        {
            var embed = await Task.Run(() => (new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(color)
                .WithThumbnailUrl("https://s3.us-east-2.amazonaws.com/stickers-for-discord/menhera-1538987951967-music.png")
                .WithFooter(x => {
                    x
                    .WithIconUrl("https://upload.wikimedia.org/wikipedia/commons/4/42/YouTube_icon_%282013-2017%29.png")
                    .WithText("Enjoy!");
                })
                .WithCurrentTimestamp().Build()));
            return embed;
        }
        public static async Task<Embed> CreateErrorEmbed(string source, string error)
        {
            var embed = await Task.Run(() => new EmbedBuilder()
                .WithTitle($"(>﹏<) Something is messed up in - {source}")
                .WithDescription($"**Details**: \n{error}")
                .WithColor(Color.Red)
                .WithThumbnailUrl("https://cdn.pixabay.com/photo/2017/02/12/21/29/false-2061131__340.png")
                .WithCurrentTimestamp().Build());
            return embed;
        }

        public static async Task<IMessage> SendSuccessAsync(this ISocketMessageChannel channel, string title, string description)
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Green)
                .WithDescription(description)
                .WithAuthor(author =>
                {
                    author
                    .WithIconUrl("https://4.bp.blogspot.com/-vg8Mbl8uoUI/XA9er4DIWUI/AAAAAAAoSc8/kv5n7UsR7zMlf0_RQ0lUyUwVczFm2bqEACLcBGAs/s1600/TW2606235.png")
                    .WithName(title);
                })
                .Build();

            var message = await channel.SendMessageAsync(embed: embed);
            return message;
        }

        public static async Task<IMessage> SendErrorsAsync(this ISocketMessageChannel channel, string title, string description)
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Red)
                .WithDescription(description)
                .WithAuthor(author =>
                {
                    author
                    .WithIconUrl("https://cdn.pixabay.com/photo/2017/02/12/21/29/false-2061131__340.png")
                    .WithName(title);
                })
                .Build();

            var message = await channel.SendMessageAsync(embed: embed);
            return message;
        }
    }
}
