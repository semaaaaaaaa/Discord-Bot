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
using System.Threading;
namespace buttons
{
    public class buttons : ModuleBase<SocketCommandContext>
    {
        [Command("button")]
        public async Task Button() {
            var builder = new ComponentBuilder().WithButton("Hello", customId: "id_1", ButtonStyle.Primary, row: 0);
            await Context.Channel.SendMessageAsync("Welcome", component: builder.Build());

        }
    }
}