﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace eCommerce.Utility
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
                                        "Contact Custommer Manage at <kimhieuqtvn@gmail.com>",name);
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

        public static bool SendPassword(String email, String name,String password)
        {
            var fromAddress = new MailAddress("kimhieuqtvn@gmail.com", "Trần Kim Hiếu");
            var toAddress = new MailAddress(email, name);
            const string fromPassword = "kissmenow";
            string subject = "[eCommerce System] - Welcome custommer " + name;
            string body = String.Format("Hi {0} Your password is: {1}. If you have some problem<br />" +
                                        "Contact Custommer Manage at <kimhieuqtvn@gmail.com>", name,password);
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

        public static bool SendOrderDetail(String email, String name, StringBuilder bodysb)
        {
            var fromAddress = new MailAddress("kimhieuqtvn@gmail.com", "Trần Kim Hiếu");
            var toAddress = new MailAddress(email, name);
            const string fromPassword = "kissmenow";
            string subject = "[eCommerce System] - Welcome custommer " + name;


            string body = bodysb.ToString();





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
