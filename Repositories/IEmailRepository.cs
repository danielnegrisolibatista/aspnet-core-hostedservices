using aspnet_core_hostedservices.Entities;
using System.Collections.Generic;

namespace aspnet_core_hostedservices.Repositories
{
    public interface IEmailRepository
    {
        public List<Email> Get10UnsentEmails();
        public void Save(Email email);
    }
}
