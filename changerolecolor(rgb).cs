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
using System.Threading;
namespace changecolorname
{
    public class changecolorname : ModuleBase<SocketCommandContext>
    {
        [Command("changergb")]
        [RequireUserPermission(Discord.GuildPermission.ManageRoles, ErrorMessage = "You need Manage Message permission for it")]
        public async Task ChangeColor(SocketRole role, int r, int g, int b)
        {

            Color color = new Color(r, g, b);

            await role.ModifyAsync(x =>
        {
            x.Color = color;

        });
        }
    }
}