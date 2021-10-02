using System.Threading;
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
namespace calc
{
    public class calc : ModuleBase<SocketCommandContext>
    {
        [Command("calc")]
        public async Task Calc() {
            var builder = new ComponentBuilder().WithButton("Hello!", customId: "id_1", ButtonStyle.Primary, row: 0);
await Context.Channel.SendMessageAsync("Test buttons!", component: builder.Build());

        }
    }
}