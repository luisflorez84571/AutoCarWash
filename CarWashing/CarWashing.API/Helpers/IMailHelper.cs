using CarWashing.Shared.Responses;

namespace CarWashing.API.Helpers
{
    namespace CarWashing.API.Helpers
    {
        public interface IMailHelper
        {
            Response<string> SendMail(string toName, string toEmail, string subject, string body);
        }
    }
}