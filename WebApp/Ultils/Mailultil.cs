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
                var host = _configuration.GetValue<string>("SendMail:SMTPHost");
                var port = int.Parse(_configuration.GetValue<string>("SendMail:SMTPPort"));
                var fromemail = _configuration.GetValue<string>("SendMail:FromEmailAddress");
                var password = _configuration.GetValue<string>("SendMail:FromEmailPassword");

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
                return false;
            }
        }
    }
}

