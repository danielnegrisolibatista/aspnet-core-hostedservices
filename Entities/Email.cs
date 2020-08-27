using System;
using System.Collections.Generic;

namespace aspnet_core_hostedservices.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string BodyMessage { get; set; }
        public List<string> Cc { get; set; }      
        public bool Sent { get; set; }

        public void MarkEmailAsSent()
        {
            Sent = true;
        }

    }
}
