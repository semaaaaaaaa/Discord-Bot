using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Net;
using Discord;
using System.Threading;
using Octokit;
namespace github
{
    public class github : ModuleBase<SocketCommandContext> {
        [Command("github")]
        public async Task Github(String username) {
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var user = await github.User.Get(username);
            var embed = new EmbedBuilder();
            embed.Color = Color.DarkGrey;
            embed.Title = $"GitHub account";
            embed.WithUrl($"{user.Url}");
            embed.WithImageUrl($"{user.AvatarUrl}");
            embed.WithFooter(footer => footer.Text = $"{user.Followers} followers");
            embed.ThumbnailUrl = $"{user.Url}";
            embed.WithDescription($"Following {user.Following} accounts \n Type: {user.Type} \n Public repos: {user.PublicRepos} \n User's location: {user.Location} \n Account created at {user.CreatedAt} ");
            embed.WithCurrentTimestamp();

    await ReplyAsync(embed: embed.Build());
        }
    }
}