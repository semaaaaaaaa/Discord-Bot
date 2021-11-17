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
            public async Task Emb(string title = null, [Remainder] string description = null)
        {

            var emb = new EmbedBuilder();
            emb.WithAuthor(Context.User);
            if (title.Contains(">"))
            {
                emb.WithTitle($"{title.Replace(">", " ")}");
            }
            else
            {
                emb.WithTitle(title);
            }
            emb.WithDescription($"{description}");
            emb.WithColor(Color.Red);
            await ReplyAsync("", false, emb.Build());

        }
            
        }
    }