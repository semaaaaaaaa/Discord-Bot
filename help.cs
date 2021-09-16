using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace ConsoleApp1
{
     public class help : ModuleBase<SocketCommandContext>
     {
        [Command("help")]
        public async Task Help() {

            var eb = new EmbedBuilder();
            eb.WithColor(Color.Red);
            eb.Title = "Help";
            eb.WithCurrentTimestamp();
            eb.WithAuthor(Context.User);
            eb.WithTitle("Our discord server's link");
            eb.WithUrl("https://discord.gg/FQ22fb2");
            await ReplyAsync(embed: eb.Build());


        }
        
        
        
    }
}
