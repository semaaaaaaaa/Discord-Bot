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

namespace Commads
{
    public class Commans : ModuleBase<SocketCommandContext>
    {
        [Command("cmd")]
        
        public async Task CommandNames() {
            
            var eb = new EmbedBuilder();
            eb.Title = "Commands";
            eb.WithCurrentTimestamp();
            eb.WithAuthor(Context.User);
            eb.WithDescription("**$av <user>** \n Gets avatar of mentioned user \n **$ban <user> <reason>** \n"
            +" Ban someone from server with reason \n **$changergb <red> <green> <blue>** \n Changes role's color (rgb) \n"+
            " **$changehex <#hex>** \n Changes role's color (hex) \n **$embmkr <title> <description>** "+
            "\n Makes embed with title and description \n **$fromepoch <unix date>**\n Converts unix date to readable\n"+
            "**$github <username>** \n Get informations about user \n"+
            "**$giverole <user> <role (no mention)>** \n Gives role to mentioned user\n"
            +"**$removerole <user> <role (no mention)>** \n Deletes role from mentioned user\n"
            +"**$help** \n Sends support server\n"
            +"**$hw <programming language>** \n Get Hello World of choosed programming language \n"
            +"**$info <user>** \n Get informations about user\n"
            +"**$kick <user> reason>** \n Kicks user from the server \n"+
            "**$logs** \n Alternative of Audit log \n"
            +"**$ping** \n Reply Back with pong! \n"
            +"**$translate <from-lang> <to-lang> <text>** \n Translates text from specified language to another one \n"
            + "**$welcome** \n Greeting new members on the server with image\n"
            +"**$unban <user id>** \n Remove user's ban from the server\n"
            +"**$unban-all** \n Removes all users' ban from the server\n");            
            await ReplyAsync(embed: eb.Build());
        }
    }
    
}