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

namespace Logs
{
    public class Logs : ModuleBase<SocketCommandContext>
    {
        
        [Command("logs")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task logsCreate() {
            
            await ReplyAsync($"Logs channel set as <#{Context.Channel.Id}>");
            Context.Client.UserJoined += Userj;
            Context.Client.UserLeft += Leftg;
            Context.Client.UserBanned += Userb;
            Context.Client.ChannelCreated += Channelc;
            Context.Client.ChannelDestroyed += channeld;
            Context.Client.RoleCreated += RoleC;
            Context.Client.RoleDeleted += RoleD;
            Context.Client.UserUnbanned += Useru;
            Context.Client.MessageReceived += Links;    
            Context.Client.ChannelUpdated += Channelu; 
            
        }
        
        public async Task Channelu(SocketChannel channel, SocketChannel channel2) {
            ulong id = Context.Channel.Id;
            ulong secid = channel.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle($"A channel updated!");
            emb.WithDescription($"#{channel} **has changed to** #{channel2}");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());
        }
        public async Task Useru(SocketUser user, SocketGuild guild) {
            ulong id = Context.Channel.Id;
            ulong secid = user.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle($"An user unbanned!");
            emb.WithDescription($"{user.Id} **has been unbanned!**");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());
        } //done
        public async Task RoleD(SocketRole role) {
            ulong id = Context.Channel.Id;
            ulong secid = role.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle($"A role created!");
            emb.WithDescription($"{role.ToString()} **has been deleted!**");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());
        } //done
        public async Task RoleC(SocketRole role) {
            ulong id = Context.Channel.Id;
            ulong secid = role.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle($"A role created!");
            emb.WithDescription($"{role.Mention} **has been created!**");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());
        } //done
        public async Task channeld(SocketChannel channel) {
            ulong id = Context.Channel.Id;
            ulong secid = channel.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle($"A channel deleted!");
            emb.WithDescription($"#{channel} **has been deleted!**");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());

        }//done
        public async Task Userb(SocketUser user, SocketGuild guild) {
            ulong id = Context.Channel.Id;
            ulong secid = user.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle(guild.ToString());
            emb.WithDescription($"{user.Mention} **banned**");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());
        }
        public async Task Leftg(SocketGuildUser guild) {
            ulong id = Context.Channel.Id;
            ulong secid = guild.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle(guild.ToString());
            emb.WithDescription($"{guild.Mention} **left the server**");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());

        } //done
        public async Task Channelc(SocketChannel channel) {
            ulong id = Context.Channel.Id;
            ulong secid = channel.Id;
            var channel1 = Context.Client.GetChannel(id) as IMessageChannel;
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle($"A channel created!");
            emb.WithDescription($"#{channel.ToString()} **has been created!** ");
            emb.WithColor(Color.DarkRed);
            emb.WithFooter(footer => footer.Text = $"Id · {secid}");
            emb.WithCurrentTimestamp();
            await channel1.SendMessageAsync(embed: emb.Build());

        } //done
        public async Task Userj(SocketGuildUser user) {
            ulong id = 879797115876941894; 
            var chnl = Context.Client.GetChannel(id) as IMessageChannel; 
            EmbedBuilder emb = new EmbedBuilder();
            emb.WithTitle(user.Nickname);
            emb.WithAuthor(user);
            emb.WithDescription($"{user.Mention} **joined the server**");
            emb.WithFooter(footer => footer.Text = $"Id · {user.Id}");
            emb.WithColor(Color.DarkRed);
            emb.WithCurrentTimestamp();
            await chnl.SendMessageAsync(embed: emb.Build());
            
        }//done
        public async Task Links(SocketMessage message)
        {
            
            string inv_link = "discord.gg";
            if (message.Content.Contains(inv_link))
            {
                await message.DeleteAsync();
                await message.Channel.SendMessageAsync("Advertisement isn't allowed");
                
            }

        } //done
    }
}