using aspnet_core_hostedservices.Entities;

namespace aspnet_core_hostedservices.Services
{
    public interface ISendMailService
    {
        public void Send(Email email);
    }
}
