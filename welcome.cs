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
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;

namespace WelcomingSystem
{

    public class Welcome : ModuleBase<SocketCommandContext>
    {
        [Command("welcome")]
        public async Task Start()
        {
            Context.Client.UserJoined += Welcoming;
        }
        public async Task Welcoming(SocketGuildUser user)
        {
            Bitmap bitmap = new Bitmap(@"C:\Users\SCC\Desktop\New folder\Projects\csharp\secdcbot\Banner.bmp");

            string firstText = user.Username.ToString();
            string secondText = user.CreatedAt.Date.ToShortDateString();
            PointF firstLocation = new PointF(230f, 270f);
            PointF secondLocation = new PointF(10f, 360f);
            PointF thirdLocation = new PointF(250f, 100f);
            string avurl = user.GetAvatarUrl();



            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Verdana", 20, FontStyle.Bold))
                {
                    Font arialFont2 = new Font("Verdana", 15, FontStyle.Bold);
                    graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation);
                    graphics.DrawString(secondText, arialFont2, Brushes.Black, secondLocation);
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] data = webClient.DownloadData(avurl);

                        using (MemoryStream mem = new MemoryStream(data))
                        {
                            using (var yourImage = System.Drawing.Image.FromStream(mem))
                            {
                                yourImage.Save("avatar.png", System.Drawing.Imaging.ImageFormat.Png);
                                graphics.DrawImage(yourImage,thirdLocation);
                            }
                        }

                    }
                    ImageCodecInfo myImageCodecInfo;
                    System.Drawing.Imaging.Encoder myEncoder;
                    EncoderParameter myEncoderParameter;
                    EncoderParameters myEncoderParameters;
                    // Get an ImageCodecInfo object that represents the JPEG codec.
                    myImageCodecInfo = GetEncoderInfo("image/jpeg");

                    myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    myEncoderParameters = new EncoderParameters(1);
                    myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bitmap.Save("Jpg.jpg", myImageCodecInfo, myEncoderParameters);


                }
            }

            await Context.Channel.SendFileAsync(@"C:\Users\SCC\Desktop\New folder\Projects\csharp\secdcbot\Jpg.jpg", $"Welcome to the server, {user.Mention}!");
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
