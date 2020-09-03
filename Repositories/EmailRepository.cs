using aspnet_core_hostedservices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_hostedservices.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private Dictionary<int, Email> _emails = new Dictionary<int, Email>();

        public EmailRepository()
        {
            for (var index = 0; index <= 30; index++)
            {
                _emails.Add(index, 
                            new Email { 
                                Id = index, 
                                Subject = $"Subject-{index}", 
                                FromEmail = $"FromEmail-{index}", 
                                FromName = $"FromName-{index}",
                                ToEmail = $"ToEmail-{index}",
                                ToName = $"ToName-{index}",
                                Sent = false
                            });
            }
            
        }

        public List<Email> Get10UnsentEmails()
        {
            try
            {
                return _emails
                        .Select(s => s.Value)
                        .ToList()
                        .Where(s => !s.Sent)
                        .Take(10)
                        .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Get10UnsentEmails {ex.Message}");
            }

            return new List<Email>();
        }

        public void Save(Email email)
        {
            try
            {
                var keyValuePairEmail = _emails
                                    .Select(s => s)
                                    .ToList()
                                    .FirstOrDefault(s => s.Value.Id == email.Id);

                _emails[keyValuePairEmail.Key] = email;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Save Email({email.Id}) {ex.Message}");
            }
        }
    }
}
