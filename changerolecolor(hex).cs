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

namespace changecolornamehex
{
    public class changecolornamehex : ModuleBase<SocketCommandContext>
    {
        [Command("changehex")]
        [RequireUserPermission(Discord.GuildPermission.ManageRoles, ErrorMessage = "You need Manage Message permission for it")]
        public async Task ChangeColor(SocketRole role, string hex)
        {
            
            Color color = (Color)System.Drawing.ColorTranslator.FromHtml(hex);
            
            await role.ModifyAsync(x =>
        {
            x.Color = color;

        });
        }
    }
}