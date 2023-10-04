using System;
using System.Net.Mail;
using System.Text;

namespace WebApp.Ultils
{
    public class Mailultil
    {
        private readonly IConfiguration _configuration;
        public Mailultil(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendMailGoogle(string _to, string _subject, string _content, string _fromname)
        {
            try
            {
                var host = "smtp.gmail.com";
                var port = 587;
                var fromemail = "onlineOHD29061@gmail.com";
                var password = "mbsy wnng jqyu hssz";

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromemail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };
                var mail = new MailMessage
                {
                    Body = _content,
                    Subject = _subject,
                    From = new MailAddress(fromemail, _fromname)
                };

                mail.To.Add(new MailAddress(_to));
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                smtpClient.Send(mail);
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string formEmail(string account, string password)
        {
            var content = $"<h1>New account of online help desk fpt for you</h1>" +
                $"<p>Email Login:<strong>{account}</strong></p>" +
                $"<p>Password:<strong>{password}</strong></p>" +
                $"<a href='http://localhost:5218/Authen/Login' target='_blank'>Click here to login</a>";
            return content;
        }
    }
}

