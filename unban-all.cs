using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Net;
using Discord;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Web;
namespace Unban {
    public class Unban : ModuleBase<SocketCommandContext>
    {
        [Command("unban-all")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage ="Make sure that you have ``Ban Members`` ")]
        public async Task UnbanAll() {
            
        var bans = await Context.Client.GetGuild(759424063130304592).GetBansAsync();
        
        foreach (Discord.Rest.RestBan ban in bans)
        {
            await Context.Guild.RemoveBanAsync(ban.User);
        }
    
        }
    }
}