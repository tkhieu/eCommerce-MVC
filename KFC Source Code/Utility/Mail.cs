using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Mail;


namespace Utility
{
    public class Mail
    {
        public static bool SendWelcome(String email,String name)
        {
            var fromAddress = new MailAddress("kimhieuqtvn@gmail.com", "Trần Kim Hiếu");
            var toAddress = new MailAddress(email, name);
            const string fromPassword = "kissmenow";
            string subject = "[eCommerce System] - Welcome custommer "+name;
            string body = String.Format("Hi {0}<br />" +
                                        "Welcome to eCommerce System. If you have some problem<br />" +
                                        "Contact Custommer Manage at <kimhieuqtvn@gmail.com>");
            bool flag = true;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (Exception)
                {
                    flag = false;
                    throw;
                }
            }
            return flag;
        }
    }
}
