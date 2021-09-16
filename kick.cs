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
namespace Kick
{
    public class Kickban : ModuleBase<SocketCommandContext> {
        [Command("kick")]
        [RequireBotPermission(Discord.GuildPermission.KickMembers, ErrorMessage = "Bot does not have a permission for kick this user")]
        [RequireUserPermission(Discord.GuildPermission.KickMembers, ErrorMessage = "You don't have a permission for kick this member")]
        public async Task kick(IGuildUser user = null, [Remainder]String reasonforkick=null) {
        
            if (user == null) {
                await ReplyAsync("You should enter a name or ping specific user");
            }
            await user.KickAsync(reasonforkick);
            await Context.Channel.SendMessageAsync($"The user `{user}` kicked for {reasonforkick}");
        }
        
    }
}