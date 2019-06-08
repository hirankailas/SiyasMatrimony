using System.Threading;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace SiyasMatrimony.API.Helper
{
    public static class GbHelper
    {
        // public bool SendSMS()
        // {
        //     string URL = "https://smsapi.engineeringtgr.com/send/?Mobile=xxxxxxxxxx&Password=xxxxxx&Message=text&To=xxxxxxxxxx&Key=xxxxxxxxxxxxxx";

        //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        //     request.Method = "GET";
        //     request.ContentType = "application/json";
        //     request.ContentLength = 0;// DATA.Length;

        //      try {
        //         WebResponse webResponse = request.GetResponse();
        //         Stream webStream = webResponse.GetResponseStream();
        //         StreamReader responseReader = new StreamReader(webStream);
        //         string response = responseReader.ReadToEnd();
        //         Console.Out.WriteLine(response);
        //         responseReader.Close();
        //     } catch (Exception xe) {
        //         Console.Out.WriteLine("-----------------");
        //         Console.Out.WriteLine(xe.Message);
        //     }
        // }

        public static bool SendMail(string userName, string email, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SiyasMatrimony", "mythriinnovation@gmail.com"));
            message.To.Add(new MailboxAddress(userName, email));
            message.Subject = "Credential Information";
            message.Body = new TextPart("plain")
            {
                Text = body
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("mythriinnovation@gmail.com", "Kailas@12345");
                ITransferProgress progress = null;
                client.Send(message, default(CancellationToken), progress);
                client.Disconnect(true);
            }

            //if(progress)

            return true;
        }
    }
}