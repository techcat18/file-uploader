using System.Threading;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace EmailFunction.Interfaces;

public interface IEmailSenderService
{
    SendGridMessage Send(string toEmail);
}