using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;


namespace Program
{
    public class Program : ModuleBase<SocketCommandContext>
    {
    
        static void Main(string[] args)
            =>
            new Program()
            .RunBotAsync()
            .GetAwaiter()
            .GetResult();
        public static DiscordSocketClient _client;
        private CommandService _commands;
        public IServiceProvider _services;
        
        public async Task RunBotAsync()
        {
            var config = new DiscordSocketConfig { MessageCacheSize = 100,
            AlwaysDownloadUsers = true,
            LogLevel = LogSeverity.Verbose,
            GatewayIntents = GatewayIntents.All };
            _client = new DiscordSocketClient(config);
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

        
            string token = "ODA2NDI3MTM5NTgyMzI4ODQy.YBpRzA.Gtbdm9ZAmg8Utbl10jiZmTto-ng";
            
            _client.Log += _client_Log;
                
            await _client.SetGameAsync("$cmd");
            await RegisterCommandsAsync();
            await _client.SetStatusAsync(UserStatus.DoNotDisturb);
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
        
        private Task _client_Log(LogMessage arg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
            

        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            
            try
            {
                var message = arg as SocketUserMessage;
                var context = new SocketCommandContext(_client, message);
                if (message.Author.IsBot) return;

                int argPos = 0;
                if (message.HasStringPrefix("$", ref argPos))
                {
                    var result = await _commands.ExecuteAsync(context, argPos, _services);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
            catch { };


        }
        

    }
}