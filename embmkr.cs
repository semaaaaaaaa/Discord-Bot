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
    namespace DiscordBot.Modules 
    {
        public class Embed : ModuleBase<SocketCommandContext>
        {
            [Command("emb")]
            [RequireUserPermission(GuildPermission.ManageMessages , ErrorMessage = "You don't have rights for this command!")]
            public async Task Emb(string title, string symbol , [Remainder]string description = null)
            {
                symbol = "<";
                var emb = new EmbedBuilder();
                emb.WithAuthor(Context.User);
                emb.WithTitle(title);
                emb.WithDescription(description);
                emb.WithColor(Color.LightGrey);
                await ReplyAsync(embed: emb.Build());

            }
            
        }
    }