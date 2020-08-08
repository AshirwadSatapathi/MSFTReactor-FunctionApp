using System;
using System.Threading.Tasks;
using Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Utility
{
    public class EmailHelper
    {
        private static string apiKey = "api-key";
        public static void SendEmail(Feedback feedback)
        {
            if (feedback.FeedbackRating == "Negative")
            {
                SendMailToClient(feedback, "We Regert for inconvienece. We'll try to improvise to make better experience for you.").Wait();
                SendMailToManagement(feedback).Wait();

            }
            else
            {
                SendMailToClient(feedback, "Thank you for your feedback.").Wait();
            }

        }

        private static async Task SendMailToClient(Feedback feedback, string message)
        {
            bool flag = false;

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("150101120018@cutm.ac.in", "ashirwad"));
            msg.AddTo(new EmailAddress(feedback.Email, feedback.Name));
            msg.Subject = "India Inc Feedback";
            msg.PlainTextContent = message;
            var response = client.SendEmailAsync(msg);

        }
        private static async Task SendMailToManagement(Feedback feedback)
        {
            bool flag = false;

            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("150101120018@cutm.ac.in", "ashirwad"));
            msg.AddTo(new EmailAddress("ashirwadsatapathi.aim@gmail.com", "Management"));
            msg.Subject = "India Inc Feedback";
            msg.PlainTextContent = feedback.FeedbackOnProduct;
            var response = client.SendEmailAsync(msg);

        }
    }
}
