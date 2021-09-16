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
namespace Helloworld_Langs
{
    public class helloworld : ModuleBase<SocketCommandContext> {
        [Command("hw")]
        
        [Alias("hw", "helloworld", "hellow", "hworld")]
        [Summary("This command shows available hello worlds in different programming languages")]
        public async Task HelloWorld([Remainder]string inputLang) {
            var emb = new EmbedBuilder();
            emb.WithCurrentTimestamp();
            emb.WithAuthor(Context.User);
            
            string lang = inputLang.ToLower();
            
            Dictionary<string, string> langs = new Dictionary<string, string>()
            {
                {"c#", "Console.Writeline(\"Hello World\");"},
                {"csharp", "Console.Writeline(\"Hello World\");"},

                {"cpp", "cout << \"Hello World\" << endl;"},
                {"c++", "cout << \"Hello World\" << endl;"},

                {"java", "System.out.println(\"Hello World\");"},

                {"js", "console.log(\"Hello World\");"},
                {"javascript", "console.log(\"Hello World\");"},

                {"python", "print(\"Hello World\")"},
                {"ruby", "puts \"Hello World\""},
                {"swift", "print(\"Hello World\")"},
                {"c", "printf(\"Hello World\");"},
            };

            if (langs.ContainsKey(lang)) {
                emb.WithTitle($"Hello World in {lang}");
                emb.WithDescription(langs[lang]);
            } else {            
                emb.WithDescription("Language not featured yet/doesn't exist.");
            }
            
            await ReplyAsync("", false, emb.Build());
        }
    }
}