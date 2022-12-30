using System.Threading.Tasks;

namespace HangFire.Web.Services
{
    interface IEmailSender
    {
        Task Sender(string userId, string message);
    }
}
