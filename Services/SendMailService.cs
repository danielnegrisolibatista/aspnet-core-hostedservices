using aspnet_core_hostedservices.Entities;
using System;

namespace aspnet_core_hostedservices.Services
{
    public class SendMailService : ISendMailService
    {
        public SendMailService()
        {
        }
        public void Send(Email email)
        {
            try
            {
                Console.WriteLine($"Email Sent {email.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error SendMailService.Send {ex.Message}");
            }
        }
    }
}
