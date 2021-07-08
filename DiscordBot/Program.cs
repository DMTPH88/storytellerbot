using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot
{
	public class Program
	{
		private DiscordSocketClient _client;

		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			_client = new DiscordSocketClient();
			_client.Log += Log;
			await _client.LoginAsync(TokenType.Bot, Properties.Resources.Token);
			await _client.StartAsync();

			CommandHandler cmdHandler = new CommandHandler(_client, new CommandService());
			cmdHandler.InstallCommandsAsync();

			// Block this task until the program is closed.
			await Task.Delay(-1);
		}

        private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}
	}
}
