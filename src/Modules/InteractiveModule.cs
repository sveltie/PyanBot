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
        private readonly CommandService _service;

        public InteractiveModule(CommandService service)
        {
            _service = service;
        }

        [Command("Help", RunMode = RunMode.Async)]
        public async Task Help()
        {
            /// CHAOSSS!!!!!!!!!
            var pages = new[] { ":grey_question:My prefix for commands is `;`\n\n:information_source: **Information**\nPyan-Chan is built with .NET Core 5, Discord.Net, and Victoria as a small project."
                                + "\nPyan-Chan is also open source and available in GitHub.\n\n:link: __[Project Link!](https://github.com/Yukii2k/Pyan-ChanBOT)__ | <:GitHub:839134969908822026> " +
                                "__[My GitHub!](https://github.com/Yukii2k)__ | <:PyanChan:839135724527288340> __[Profile Sauce](https://twitter.com/hagi_neco)__\n\n:notes: __**Music Bot Commands**__ :notes:"
                                + "\n>>> `;help` - Show the help command\n`;join` - I will join your audio channel\n`;Play or ;p *music title*` - I will play the music for you!\n`;skip` - Skip to the next track"
                                + "\n`;list` - Show the queued track list\n`;Stop` - Stop and clear all the tracks\n`;Leave` - I will disconnect from the voice channel\n`;Volume *0-150*` - Adjust the bot volume" +
                                "\n`;Pause` - Pause the current playing track\n`;Resume` - Resume the Paused track\n\nReact with :arrow_forward: to go to the next page",
                                "<:Woww:839112494806728714> __**Useful Commands**__ <:Woww:839112494806728714>\n> `;info *@user*` - Get some information about the user\n\n:heart: __**Interactive Commands**__ :heart:" +
                                "\n>>> `;pat *@user*` - Pat people with this command!\n`;kiss *@user*` - Kiss people with this command!\n`;hug *@user*` - Hug people with this command! \n\n\n\nReact with :arrow_backward: to go to the previous page"};

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
