using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Discord.Net.WebSockets;
using Discord;
namespace pingpong
{
    public class pingpong : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingPong() {
            await ReplyAsync("pong");
        }
    }
}