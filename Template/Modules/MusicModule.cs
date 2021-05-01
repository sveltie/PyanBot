﻿using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victoria;
using Victoria.Enums;

namespace Pyan.Modules
{
    public class MusicModule : ModuleBase<SocketCommandContext>
    {
        private readonly LavaNode _lavaNode;

        public MusicModule(LavaNode lavaNode)
        {
            _lavaNode = lavaNode;
        }

        [Command("Join", RunMode = RunMode.Async)]
        public async Task JoinAsync()
        {
            if (_lavaNode.HasPlayer(Context.Guild))
            {
                await ReplyAsync("I'm already connected to a voice channel!");
                return;
            }

            var voiceState = Context.User as IVoiceState;
            if (voiceState?.VoiceChannel == null)
            {
                await ReplyAsync("You must be connected to a voice channel!");
                return;
            }

            try
            {
                await _lavaNode.JoinAsync(voiceState.VoiceChannel, Context.Channel as ITextChannel);
                await ReplyAsync($"Joined {voiceState.VoiceChannel.Name}");
            }
            catch (Exception exception)
            {
                await ReplyAsync(exception.Message);
            }
        }

        [Command("Play", RunMode = RunMode.Async)]
        public async Task PlayAsync([Remainder]string query) 
        { 
            if (string.IsNullOrWhiteSpace(query)) 
            {
                await ReplyAsync("Please provide search terms.");
                return;
            }

            if (!_lavaNode.HasPlayer(Context.Guild)) 
            {
                await ReplyAsync("I'm not connected to a voice channel.");
                return;
            }

            var searchResponse = await _lavaNode.SearchYouTubeAsync(query); 
            if (searchResponse.LoadStatus == LoadStatus.LoadFailed ||
                searchResponse.LoadStatus == LoadStatus.NoMatches) 
            {
                await ReplyAsync($"I wasn't able to find anything for `{query}`.");
                return;
            }

            var player = _lavaNode.GetPlayer(Context.Guild);

            if (player.PlayerState == PlayerState.Playing || player.PlayerState == PlayerState.Paused)
            {
                var track = searchResponse.Tracks[0];
                player.Queue.Enqueue(track);
                await ReplyAsync($"Enqueued: {track.Title}");
            }
            else
            {
                var track = searchResponse.Tracks[0];

                await player.PlayAsync(track);
                await ReplyAsync($"Now Playing: {track.Title}");
            }
        }

        [Command("Skip", RunMode = RunMode.Async)]
        public async Task Skip()
        {
            var voiceState = Context.User as IVoiceState;
            if (voiceState?.VoiceChannel == null)
            {
                await ReplyAsync("You must be connected to a voice channel!");
                return;
            }

            if (!_lavaNode.HasPlayer(Context.Guild))
            {
                await ReplyAsync("I'm not connected to a voice channel!");
                return;
            }

            var player = _lavaNode.GetPlayer(Context.Guild);
            if (voiceState.VoiceChannel != player.VoiceChannel)
            {
                await ReplyAsync("You need to be in the same voice channel as me!");
                return;
            }

            if(player.Queue.Count == 0)
            {
                await ReplyAsync("There are no m ore songs in the queue!");
                return;
            }

            await player.SkipAsync();
            await ReplyAsync($"Skipped! Now playing **{player.Track.Title}**!");
        }
    }
}
