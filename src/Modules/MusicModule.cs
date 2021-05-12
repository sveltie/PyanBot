using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Pyan.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victoria;
using Victoria.Enums;

namespace Pyan.Modules
{
    [Name("Music")]
    public class MusicModule : ModuleBase<SocketCommandContext>
    {
        public LavaLinkAudio AudioService { get; set; }

        [Command("Join")]
        public async Task Join()
            => await ReplyAsync(embed: await AudioService.JoinAsync(Context.Guild, Context.User as IVoiceState, Context.Channel as ITextChannel));

        [Command("Leave")]
        public async Task Leave()
            => await ReplyAsync(embed: await AudioService.LeaveAsync(Context.Guild));

        [Command("Play")]
        [Alias("P")]
        public async Task Play([Remainder] string search)
            => await ReplyAsync($":mag_right: Looking for `{search}`", embed: await AudioService.PlayAsync(Context.User as SocketGuildUser, Context.Guild, search));

        [Command("Stop")]
        public async Task Stop()
            => await ReplyAsync(embed: await AudioService.StopAsync(Context.Guild));

        [Command("List")]
        public async Task List()
            => await ReplyAsync(embed: await AudioService.ListAsync(Context.Guild));

        [Command("Skip")]
        public async Task Skip()
            => await ReplyAsync(embed: await AudioService.SkipTrackAsync(Context.Guild));

        [Command("Volume")]
        public async Task Volume(int volume)
            => await ReplyAsync(await AudioService.SetVolumeAsync(Context.Guild, volume));

        [Command("Pause")]
        public async Task Pause()
            => await ReplyAsync(await AudioService.PauseAsync(Context.Guild));

        [Command("Resume")]
        public async Task Resume()
            => await ReplyAsync(await AudioService.ResumeAsync(Context.Guild));
    }
}
