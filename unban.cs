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
namespace unban
{
    public class Unban : ModuleBase<SocketCommandContext> {
        
        [Command("unban")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers, ErrorMessage = "You don't have a permission for unban someone")]
        [RequireBotPermission(Discord.GuildPermission.BanMembers, ErrorMessage = "Bot does not have a permission for unban this user")]
        public async Task banUser(ulong id) {
        
            await Context.Guild.RemoveBanAsync(id);
            await ReplyAsync($"Done! User with {id} id has been unbanned!");
        }
    }
}