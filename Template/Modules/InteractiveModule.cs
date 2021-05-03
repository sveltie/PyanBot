using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyan.Modules
{
    public class InteractiveModule : InteractiveBase
    {
        [Command("Help", RunMode = RunMode.Async)]
        public async Task Help()
        {
            var pages = new[] { "My prefix for commands is `;`   <:KannaSip:838739588573823038>\n\n**Information**\nPyan-Chan is built with .NET Core 5, Discord.Net, and Victoria as a small project." +
                "\nPyan-Chan is also open source and available in GitHub.\n\n__[Project Link](https://github.com/Yukii2k)__\nCurrently unavailable due to some error (deleted the old version)\n\n:scroll:__**These are the commands list**__:scroll:" +
                "\n>>> `;help` : Show the help command\n`;join` : The Bot will join your audio channel\n`;Play *music title or YouTube link*` : I will play the music for you, master!\n `;skip` : Skip to the next track" +
                "\n`;list` : Show the queued track list\n`;Stop` : Stop and clear all the tracks\n`;Leave` : I will disconnect from the voice channel\n`;Volume *0-150*` : Adjust the bot volume\n`;Pause` : Pause the current playing track\n`;Resume` : Resume the Paused track " };

            PaginatedMessage paginatedMessage = new PaginatedMessage()
            {
                Pages = pages,
                Options = new PaginatedAppearanceOptions()
                {
                    Jump = new Emoji(""),
                    Info = new Emoji(""),
                },
                Color = new Discord.Color(255, 166, 207),
                Title = "Pyan-Chan Help"
            };

            await PagedReplyAsync(paginatedMessage);
        }
    }
}
