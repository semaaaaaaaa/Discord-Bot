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
namespace epochConverter
{
    public class epochConverter : ModuleBase<SocketCommandContext>
    {
        [Command("fromepoch")]
        
        public async Task epochToDate(int epoch) {
            DateTimeOffset idkwhatshouldinameit = DateTimeOffset.FromUnixTimeSeconds(epoch);
            await ReplyAsync(idkwhatshouldinameit.ToString());
            
        }
    }
}