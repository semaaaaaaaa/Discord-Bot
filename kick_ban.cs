using System;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.Net.WebSockets;
using Discord.Commands;
using Discord.WebSocket;
namespace Ban_Command
{
    public class Ban : ModuleBase<SocketCommandContext>
    {
         [Command("ban")]
        public async Task Banuser(IGuildUser userAccount,string reason = null)
        {
            var user = Context.User as SocketGuildUser;

            if (!userAccount.GuildPermissions.Administrator)
            {
                if (user.GuildPermissions.BanMembers)
                {
                    await userAccount.BanAsync();
                    await Context.Channel.SendMessageAsync($"The user `{userAccount}` has been banned, for {reason}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("No permissions for banning a user.");
                }
            }
            else
            {
                await ReplyAsync("You can't ban Admin");
            }
        }
    }
}