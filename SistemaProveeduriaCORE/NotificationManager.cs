using DTOs;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace SistemaProveeduriaCORE
{
    public class NotificationManager
    {
        public void Notify(Usuario user) { }
        public async void NotifyUserByEmail(string otp, string mail)
        {
            UserExecute(otp, mail).Wait();
        }
        public void NotifyUserBySMS(string otp, string phoneNumber)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "AC7122fd8ae45961bb509c18265cacb7af";
            string authToken = "a1a67e5de310d2536cd397c4ff517b2e";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "El OTP es: " + otp,
                from: new Twilio.Types.PhoneNumber("+15076367688"),
                to: new Twilio.Types.PhoneNumber("+" + phoneNumber)
            );

            Console.WriteLine(message.Sid);

        }
        static async Task UserExecute(string otp, string mail)
        {
            //var apiKey = "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";
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kngz@ucenfotec.ac.cr", "Michael Ng");
            var subject = "Creacion de la cuenta";
            var to = new EmailAddress(mail, "Usuario");
            var plainTextContent = $"Hola, el codigo es {otp}";
            var htmlContent = $"Hola, el codigo es {otp}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}