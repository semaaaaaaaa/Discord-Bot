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
namespace Calculator
{
    public class Calculator : ModuleBase<SocketCommandContext> {
        [Command("calc")]
        public async Task calculatorBot() {
            var builder = new ComponentBuilder().WithButton("1", customId: "id_1", ButtonStyle.Primary, row: 0);
            var builder2 = new ComponentBuilder().WithButton("2", customId: "id_1", ButtonStyle.Primary, row: 0);
            var builder3 = new ComponentBuilder().WithButton("3", customId: "id_1", ButtonStyle.Primary, row: 0);
            var builder4 = new ComponentBuilder().WithButton("4", customId: "id_1", ButtonStyle.Primary, row: 0);
            var builder5 = new ComponentBuilder().WithButton("5", customId: "id_1", ButtonStyle.Primary, row: 0);

            await Context.Channel.SendMessageAsync(builder.Build(), builder2.Build(),builder3.Build(),builder4.Build());
        }
    }
}