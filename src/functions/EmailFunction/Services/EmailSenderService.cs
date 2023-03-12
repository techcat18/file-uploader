using EmailFunction.Interfaces;
using SendGrid.Helpers.Mail;

namespace EmailFunction.Services;

public class EmailSenderService: IEmailSenderService
{
    public SendGridMessage Send(string toEmail)
    {
        var msg = new SendGridMessage
        {
            From = new EmailAddress("techcat18@gmail.com", "Kostia"),
            Subject = "File upload to the blob storage",
            PlainTextContent = "Thanks for uploading your file to the blob storage!",
            HtmlContent = "<h2 style=\"text-align: center\">Thanks for uploading your file to the blob storage!</h2>"
        };
            
        msg.AddTo(new EmailAddress(toEmail));

        return msg;
    }
}