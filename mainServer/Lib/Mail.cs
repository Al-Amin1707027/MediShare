using MailKit.Net.Smtp;
using MimeKit;

namespace Mail
{
    public class MailClient {
        
        public static void SendVerifyEmail(string address, string code) {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("MediShare", 
            "alaminbdgb@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("MediShare", address);
            message.To.Add(to);

            message.Subject = "Verify your Account";
            
            
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Verify your Account!</h1> <a href='https://localhost:5001/VerifyEmail?email="+address+"&verify_code="+code+"'>Verify Now</a>";
            bodyBuilder.TextBody = "Email from MediShare";
            
            message.Body = bodyBuilder.ToMessageBody();
            
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("alaminbdgb@gmail.com", "1111111111");
            
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}