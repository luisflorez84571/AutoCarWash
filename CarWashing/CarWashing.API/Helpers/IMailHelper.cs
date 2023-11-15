using CarWashing.Shared.Responses;

namespace CarWashing.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}
