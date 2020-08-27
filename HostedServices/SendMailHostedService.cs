using aspnet_core_hostedservices.Entities;
using aspnet_core_hostedservices.Repositories;
using aspnet_core_hostedservices.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace aspnet_core_hostedservices.HostedServices
{
    public class SendMailHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        public IServiceProvider ServiceProvider { get; set; }
        public SendMailHostedService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
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

            using (var scope = ServiceProvider.CreateScope())
            {
                var emailRepository = scope.ServiceProvider.GetRequiredService<IEmailRepository>();
                var sendMailService = scope.ServiceProvider.GetRequiredService<ISendMailService>();

                var unsentEmails = emailRepository.Get10UnsentEmails();
                foreach (var unsentEmail in unsentEmails)
                {
                    sendMailService.Send(unsentEmail);

                    unsentEmail.MarkEmailAsSent();
                    emailRepository.Save(unsentEmail);
                }
            }

            Console.WriteLine("End SendMailHostedService");
        }
    }
}
