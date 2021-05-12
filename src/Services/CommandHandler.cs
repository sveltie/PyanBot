using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Pyan.Handlers;
using Victoria;

namespace Pyan.Services
{
    public class CommandHandler : InitializedService
    {
        private readonly IServiceProvider _provider;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _service;
        private readonly IConfiguration _config;
        private readonly LavaNode _lavaNode;

        public CommandHandler(IServiceProvider provider, DiscordSocketClient client, CommandService service, IConfiguration config, LavaNode lavaNode)
        {
            _provider = provider;
            _client = client;
            _service = service;
            _config = config;
            _lavaNode = lavaNode;

        }

        public override async Task InitializeAsync(CancellationToken cancellationToken)
        {
            _client.MessageReceived += OnMessageReceived;
            _client.Ready += OnReadyAsync;
            _client.JoinedGuild += OnJoinedGuild; ///this serves only to watch how many server the bot is currently in. Currently it has no purpose but for custom status.
            _client.LeftGuild += OnLeftGuild; ///this serves only to watch how many server the bot is currently in. Currently it has no purpose but for custom status. -Pyan/Yukii

            _service.CommandExecuted += OnCommandExecuted;
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);
        }
        private async Task OnLeftGuild(SocketGuild arg)
        {
            await _client.SetGameAsync($"with my master | ;help", null, ActivityType.Playing);
        }

        private async Task OnJoinedGuild(SocketGuild arg)
        {
            await _client.SetGameAsync($"with my master | ;help", null, ActivityType.Playing);
        }

        private async Task OnReadyAsync()
        {
            if (!_lavaNode.IsConnected)
            {
                await _lavaNode.ConnectAsync();
            }
        }

        private async Task OnMessageReceived(SocketMessage arg)
        {
            if (!(arg is SocketUserMessage message)) return;
            if (message.Source != MessageSource.User) return;

            var argPos = 0;
            if (!message.HasStringPrefix(_config["prefix"], ref argPos) && !message.HasMentionPrefix(_client.CurrentUser, ref argPos)) return;

            var context = new SocketCommandContext(_client, message);
            await _service.ExecuteAsync(context, argPos, _provider);
        }

        private async Task OnCommandExecuted(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (command.IsSpecified && !result.IsSuccess) await (context.Channel as ISocketMessageChannel).SendErrorsAsync("Error", result.ErrorReason);
        }
    }
}