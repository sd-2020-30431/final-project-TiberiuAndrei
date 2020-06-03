using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BankingApp.BusinessLogic
{
    public class MailManager
    {
        public void sendMail(string fromAddress, string fromPassword, string toAddress, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
            client.Credentials = new NetworkCredential(fromAddress, fromPassword);
            client.EnableSsl = true;
            client.Send(mailMessage);
        }

    }

}
