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
namespace calc
{
    public class calc : ModuleBase<SocketCommandContext>
    {
        [Command("calc")]
        [Alias("resources")]
        public async Task Resources()
        {

            ComponentBuilder builder = new ComponentBuilder();

            builder.WithButton("1", "1", ButtonStyle.Primary, null, null, false, row: 0);
            builder.WithButton("2", "2", ButtonStyle.Primary, null, null, false, row: 0);
            builder.WithButton("3", "3", ButtonStyle.Primary, null, null, false, row: 0);
            builder.WithButton("4", "4", ButtonStyle.Primary, null, null, false, row: 0);
            builder.WithButton("5", "5", ButtonStyle.Primary, null, null, false, row: 0);
            builder.WithButton("6", "6", ButtonStyle.Primary, null, null, false, row: 1);
            builder.WithButton("7", "7", ButtonStyle.Primary, null, null, false, row: 1);
            builder.WithButton("8", "8", ButtonStyle.Primary, null, null, false, row: 1);
            builder.WithButton("9", "9", ButtonStyle.Primary, null, null, false, row: 1);
            builder.WithButton("0", "0", ButtonStyle.Primary, null, null, false, row: 1);

            builder.WithButton("+", "+", ButtonStyle.Primary, null, null, false, row: 2);
            builder.WithButton("-", "-", ButtonStyle.Primary, null, null, false, row: 2);
            builder.WithButton("/", "/", ButtonStyle.Primary, null, null, false, row: 2);
            builder.WithButton("*", "*", ButtonStyle.Primary, null, null, false, row: 2);
            builder.WithButton("=", "=", ButtonStyle.Primary, null, null, false, row: 2);


            await Context.Channel.SendMessageAsync("Calculator", component: builder.Build());
            Context.Client.InteractionCreated += Client_InteractionCreated;

        }


        private async Task Client_InteractionCreated(SocketInteraction interaction)
        {
            switch (interaction)
            {
                case SocketMessageComponent componentInteraction:
                    await MyMessageComponentHandler(componentInteraction);
                    break;

                // Unused or Unknown/Unsupported
                default:
                    break;
            }
        }
        private async Task MyMessageComponentHandler(SocketMessageComponent interaction)
        {

            var customId = interaction.Data.CustomId;

            var user = (SocketGuildUser)interaction.User;

            var guild = user.Guild;
            MessageProperties msgProps = new MessageProperties();
            
            await interaction.UpdateAsync(msgProps => msgProps.Content = $"{customId}");
            
            //await interaction.FollowupAsync($"Clicked {interaction.Data.CustomId}!", ephemeral: true);

        }
    }
}