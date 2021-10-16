using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Net;
using Discord;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.Web;
namespace translate
{
    class Translate
    {
        
        public String translateText(String word, string toLanguage, string fromLanguage)
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
    }
    public class translateText : ModuleBase<SocketCommandContext>
    {
        [Command("translate")]
        public async Task Translatethistext(string fromlang,string tolang, [Remainder] string message)
        {
            
            Translate translate = new Translate();
            await ReplyAsync(translate.translateText(message, tolang, fromlang));
        }
    }
}