
namespace aspnet_core_hostedservices.Entities
{
    public class SmtpInfo
    {
        public string Server { get; set; }

        public int Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public bool HasCertified { get; set; }

        public string EmailFromSender { get; set; }

        public string EmailErrorDefault { get; set; }

        public bool IsAuthenticatedInRelay { get; set; }
    }
}
