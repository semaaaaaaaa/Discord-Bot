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
using System.Drawing;
namespace info
{
    public class info : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        public async Task Info(SocketGuildUser user = null)
        {
            if (user != null) {
            string dataofcreation = user.CreatedAt.ToString();
            bool isbot = user.IsBot;
            string av = user.GetAvatarUrl();
            var other = user.PublicFlags;
            var other2 = user.Id;
            var other3 = user.Status;
            var embed = new EmbedBuilder();
            embed.WithAuthor(user)
            .WithFooter(footer => footer.Text = "User Informations")
            .WithTitle($"Informations about {user}")
            .WithThumbnailUrl(av)
            .WithDescription($"\n\n **ID**: {other2} \n\n **Joined Discord**: {dataofcreation} \n\n **Joined Server**: {user.JoinedAt} \n\n**Is Bot**: {isbot.ToString()} \n\n **Badges**: {other} \n\n **Status**: {other3} \n\n **Is muted**: {user.IsMuted.ToString()}")
            .WithCurrentTimestamp();
            await ReplyAsync(embed: embed.Build());
            }
            else if (user == null) {
            var embed2 = new EmbedBuilder();
            embed2.WithAuthor(Context.User)
            .WithFooter(footer => footer.Text = "Server Informations")
            .WithTitle($"**{Context.Guild}**")
            .WithThumbnailUrl(Context.Guild.IconUrl)
            .WithDescription($"\n\n **ID**: {Context.Guild.Id} \n **Created at**: {Context.Guild.CreatedAt} \n **Rules channel**: {Context.Guild.RulesChannel} \n **Members**: {Context.Guild.MemberCount} \n")
            .WithCurrentTimestamp();
            await ReplyAsync(embed: embed2.Build());
            }
        }
    }
}
