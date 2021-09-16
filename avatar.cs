using System.Threading;
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
namespace botsendmessage
{
    public class botsendmessage : ModuleBase<SocketCommandContext>
    {
        [Command("av")]
        public async Task GetAvatarAsync(IUser user = null)
        {

            if (user == null)
            {
                if (Context.Guild.IconUrl != null) {
                var serveravurl = Context.Guild.IconUrl;
                await ReplyAsync(serveravurl);
                return;
                }
                if (Context.Guild.IconUrl == null) {
                    await ReplyAsync("Server has no icon");
                    return;
                }
            }
            else if (user != null)
            {
                var userAvatarUrl = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();
                await ReplyAsync(userAvatarUrl);
            }

        }

    }
} //done