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
namespace ban
{
    public class Ban : ModuleBase<SocketCommandContext> {
        
        [Command("ban")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers, ErrorMessage = "You don't have a permission for ban someone")]
        [RequireBotPermission(Discord.GuildPermission.BanMembers, ErrorMessage = "Bot does not have a permission for ban this user")]
        public async Task banUser(IGuildUser user = null, [Remainder]String reasonforban=null) {
        
            if (user == null) {
                await ReplyAsync("You should enter a name or ping specific user");
            }
            if (reasonforban ==null) return;
            await Context.Guild.AddBanAsync(user,1, reasonforban);
            await Context.Channel.SendMessageAsync($"The user `{user}` banned for {reasonforban}");
        }
    }
}