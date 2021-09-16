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
using System.Drawing;

namespace Commads
{
    public class Commans : ModuleBase<SocketCommandContext>
    {
        [Command("cmd")]
        
        public async Task CommandNames() {
            
            var eb = new EmbedBuilder();
            eb.Title = "Commands";
            eb.WithCurrentTimestamp();
            eb.WithAuthor(Context.User);
            eb.WithTitle("Commands:");
            eb.WithDescription("**$removerole** <user> <role>\n"+"**$giverole** <user> <role>\n"+"**$mute** <user> \n"+"**$ban** <user> <reason>\n"+"**$kick**<user> <reason>\n"+"**$hw** <programming language>\n"+"**$emb** <title> `<` <text>\n"+"**$help**\n"+ "**$av**<user>\n**$info**<user>\n**$logs**");
            await ReplyAsync(embed: eb.Build());
        }
    }
    
}