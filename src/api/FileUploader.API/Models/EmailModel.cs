using SendGrid.Helpers.Mail;

namespace FileUploader.API.Models
{
    public class EmailModel
    {
        public EmailAddress From { get; set; }
        public EmailAddress To { get; set; }
        public string Subject { get; set; }
        public string TextContent { get; set; }
    }
}