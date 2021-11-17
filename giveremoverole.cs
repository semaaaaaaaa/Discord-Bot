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
namespace giveremove
{
    public class giveremove : ModuleBase<SocketCommandContext>
    {
        [Command("giverole")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have rights for this role!")]
        public async Task GiveRole(IGuildUser user, [Remainder] string roles)
        {

            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == roles);
            await (user as IGuildUser).AddRoleAsync(role);
            await ReplyAsync($"Done! {role.ToString()} role for {user.Mention} was added!");
        }
        [Command("removerole")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You don't have rights for this role!")]
        public async Task RemoveRole(IGuildUser user, [Remainder]string roles)
        {
            if (user==null) return;
            if(roles==null) return;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == roles);
            await (user as IGuildUser).RemoveRoleAsync(role);
            await ReplyAsync($"Done! {role.ToString()} from {user.Mention} was deleted");
        }
    }
}