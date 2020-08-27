using aspnet_core_hostedservices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_hostedservices.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private List<Email> _emails;

        public EmailRepository()
        {
            _emails = new List<Email>();

            for (var i = 0; i <= 30; i++)
            {
                _emails.Add(
                    new Email
                    {
                        Id = i,
                        FromEmail = $"from.{i}.email@email.com",
                        FromName = $"from.{i}.name",
                        ToEmail = $"to.{i}.email@email.com",
                        ToName = $"to.{i}.name",
                        Subject = $"Subject.{i}",
                        BodyMessage = $"BodyMessage.{i}"
                    }    
                );
            }
            
        }

        public List<Email> Get10UnsentEmails()
        {
            return _emails
                    .Where(w => !w.Sent)
                    .Take(10)
                    .ToList();
        }

        public void Save(Email email)
        {
            var selectedEmail = _emails.FirstOrDefault(d => d.Id == email.Id);

            if (selectedEmail != null) {
                selectedEmail.Sent = email.Sent;
            }
        }
    }
}
