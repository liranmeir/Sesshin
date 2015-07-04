using Sesshin.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Sesshin.Service.Contracts;

namespace Sesshin.Service
{
    public class EmailService : IEmailService
    {
        public void SendEmail(Contact contact)
        {
            try
            {
                var mailTo = System.Web.Configuration.WebConfigurationManager.AppSettings["MailTo"];
                var mailFrom = System.Web.Configuration.WebConfigurationManager.AppSettings["MailFrom"];
                var mailLoginUser = System.Web.Configuration.WebConfigurationManager.AppSettings["MailLoginUser"];
                var mailLoginUserPass = System.Web.Configuration.WebConfigurationManager.AppSettings["MailLoginUserPass"];

                var mailingList = mailTo.Split(';').ToList();

                var loginInfo = new NetworkCredential(mailLoginUser, mailLoginUserPass);
                var msg = new MailMessage();

                var smtpClient = new SmtpClient("mail.sesshin.co.il", 25);

                msg.From = new MailAddress(mailFrom, "Sesshin");

                foreach (var email in mailingList)
                {
                    msg.To.Add(new MailAddress(email));
                }

                msg.Subject = "השארת פרטים בסשין";
                msg.Body = contact.ToEmailText();

                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
            }
            catch (Exception exception)
            {
                //log exception  
                throw;
            }
        }
    }
}
