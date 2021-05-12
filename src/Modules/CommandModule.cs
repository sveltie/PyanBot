using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pyan.Modules
{
    public class CommandModule : ModuleBase<SocketCommandContext>
    {

        [Command("8ball")]
        [Alias("Ask")]
        public async Task EightBall(params string[] args)
        {
            string[] answer = { "**Yes**", "**No**" , "**Maybe..**" };
            Random random = new Random();
            int index = random.Next(answer.Length);
            var builder = new EmbedBuilder()
                .WithTitle("This is your answer")
                .WithColor(new Color(143, 143, 143))
                .WithCurrentTimestamp()
                .WithDescription($"{answer[index]}");
            var embed = builder.Build();
            if (args.Length == 0)

            {
                await ReplyAsync("You have to say something in order to recieve a prediction!");
            }
            else
            {
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
        }
    }
}
