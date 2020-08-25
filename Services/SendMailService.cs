using aspnet_core_hostedservices.Entities;
using System;
using System.Net.Mail;

namespace aspnet_core_hostedservices.Services
{
    public class SendMailService : ISendMailService
    {
        private readonly SmtpInfo _infoServer;

        public SendMailService(SmtpInfo infoServer)
        {
            _infoServer = infoServer;
        }
        public void Send(Email email)
        {
            try
            {
                var mailMessage = new MailMessage(email.FromEmail, email.ToEmail, email.Subject, email.BodyMessage);
               
                using (var client = new SmtpClient(_infoServer.Server, _infoServer.Port))
                {
                    client.Send(mailMessage);
                    client.Dispose();
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
