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
            if (user != null)
            {
                string dataofcreation = user.CreatedAt.Date.ToShortDateString();
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
                .WithDescription($"\n **ID**: {other2} \n **Joined Discord**: {dataofcreation} \n **Joined Server**: {user.JoinedAt.Value.Date.ToShortDateString()} \n**Is Bot**: {isbot.ToString()} \n **Badges**: {other} \n"+" **Status**: "+ (other3.ToString() == "DoNotDisturb" ? "Do Not Disturb" : other3.ToString() == "Online" ? "Online" : other3.ToString() == "Idle" ? "Idle" : "Offline") +" \n")
                .WithCurrentTimestamp();
                await ReplyAsync(embed: embed.Build());
            }
            else if (user == null)
            {
                 var role = Context.Guild.Roles;
                 var value = String.Join(", ",role.AsEnumerable());
                var embed2 = new EmbedBuilder();
                embed2.WithAuthor(Context.User)
                .WithFooter(footer => footer.Text = "Server Informations")
                .WithTitle($"**{Context.Guild}**")
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithDescription($"\n\n **ID**: {Context.Guild.Id} \n"
                + $"**Created at**: {Context.Guild.CreatedAt} \n "
                + $"**Rules channel**: {Context.Guild.RulesChannel.Mention}\n"
                + $" **Members**: {Context.Guild.MemberCount} \n"
                + $"**Owner**: {Context.Guild.Owner.Mention}\n"
                +$"**Verification level**: {Context.Guild.VerificationLevel}\n"
                +$"**2FA for Moderation**: {Context.Guild.MfaLevel}");
                
                embed2.WithCurrentTimestamp();
                await ReplyAsync(embed: embed2.Build());
                
            }
        }
    }
}
