using aspnet_core_hostedservices.Repositories;
using aspnet_core_hostedservices.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_hostedservices.HostedServices
{
    public class SendMailHostedService : IHostedService, IDisposable
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ISendMailService _sendMailService;
        private Timer _timer;

        public IServiceProvider ServiceProvider { get; set; }
        public SendMailHostedService(IServiceProvider serviceProvider, IEmailRepository emailRepository, ISendMailService sendMailService)
        {
            ServiceProvider = serviceProvider;
            _emailRepository = emailRepository;
            _sendMailService = sendMailService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendMail, null, 0, 5000);

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
        private void SendMail(object state)
        {
            Console.WriteLine("Begin SendMailHostedService");

            var unsentEmails = _emailRepository.Get10UnsentEmails();

            Console.WriteLine($"There is {unsentEmails.Count} email to send");

            foreach (var unsentEmail in unsentEmails)
            {
                _sendMailService.Send(unsentEmail);

                unsentEmail.MarkEmailAsSent();
                _emailRepository.Save(unsentEmail);
            }

            Console.WriteLine("End SendMailHostedService");
        }
    }
}
