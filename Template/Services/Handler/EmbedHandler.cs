using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyan.Handlers
{
    public static class EmbedHandler
    {
        public static async Task<Embed> CreateBasicEmbed(string title, string description, Color color)
        {
            var embed = await Task.Run(() => (new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(color)
                .WithThumbnailUrl("https://lh3.googleusercontent.com/proxy/1aegHwWWYRrL2gVRznkSm8jRJE676hslpxdRJ1i2EDDjX3EGkm8uwlfLWYTuzLhzHXjSWnr4GcAsufzolLVYe38s58-KHyBzQqoZcGDx5R40b_PBibsIouOQoI0jZbRM1VmWwcjchmk0oZkO7YnmazC1CnT502fLdYzKp2RScMp3RVWb-g")
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
