using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Services.Description;

namespace LinhDGT_Electronic.Common
{
    public class Common
    {
        private static string password = ConfigurationManager.AppSettings["PasswordEmail"];
        private static string email = ConfigurationManager.AppSettings["Email"];
        public static bool SendEmail(string name, string subject, string content, string ReceiverMail)
        {
            bool rs = false;

            try
            {
                MailMessage message = new MailMessage();
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    //ĐỊA CHỈ SMTP Server
                    smtp.Host = "smtp.gmail.com";
                    //Cổng SMTP
                    smtp.Port = 587;
                    //SMTP yêu cầu mã hóa dữ liệu theo SSL
                    smtp.EnableSsl = true;
                    //UserName và Password của mail

                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential()
                    {
                        UserName = email,
                        Password = password
                    };
                }
                //Tham số lần lượt là địa chỉ người gửi, người nhận, tiêu đề và nội dung thư
                MailAddress fromMail = new MailAddress(email, name);
                message.From = fromMail;
                message.To.Add(ReceiverMail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;
                smtp.Send(message);
                rs = true;
            }
            catch (Exception)
            {
                rs = false;
            }
            return true;
        }
    }
}