using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Capstone.Models;
using System.Text;

namespace Capstone.Security
{
    public class EmailTools
    {
        //User user = new User();
        //string emailFrom = "fitnesstrackerorange21@gmail.com";
        //string subject = "Password Change";
        //string body = "<h1>Hello, your password has been changed</h1>";

        //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        //{
        //    Port = "smtp.gmail.com",
        //    Credentials = new NetworkCredential("fitnesstrackerorange21@gmail.com", "googlesucks14"),
        //    EnableSsl = true,
        //};



        //MailMessage mailMessage = new MailMessage
        //{
        //    From = new MailAddress("fitnesstrackerorange21@gmail.com"),
        //    Subject = "Password Change",
        //    Body = "<h1>Hello, your password has been changed</h1>",
        //    IsBodyHtml = true,

        //};

        public  bool EmailPasswordChangeConfirmation(string emailRecipient)
        {
            bool result = false;

            string to = emailRecipient;  
            string from = "fitnesstrackerorange21@gmail.com"; //From address
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(from);
                mailMessage.To.Add(to);
                mailMessage.Subject = "Password Change";
                mailMessage.Body = "<h1>This message confirms your password has changed.</h1>";
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential(from, "googlesucks14");
                    //System.Net.NetworkCredential basicCredential1 =
                       // new System.Net.NetworkCredential("fitnesstrackerorange21@gmail.com", "googlesucks14");
                    client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = basicCredential1;
                    try
                    {
                        client.Send(mailMessage);
                        result = true;
                    }

                    catch (Exception ex)
                    {
                        result = false;
                        //todo logiing here
                    }





                    return result;
                }
            }
        }
        public bool EmailRegistrationConfirmation(string emailRecipient, string username)
        {
            bool result = false;

            string to = emailRecipient;
            string from = "fitnesstrackerorange21@gmail.com"; //From address
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(from);
                mailMessage.To.Add(to);
                mailMessage.Subject = "New Account Created";
                mailMessage.Body = $"<h1>Hello! Welcome to your fitness journey. Your username is: {username}</h1>";
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential(from, "googlesucks14");
                    //System.Net.NetworkCredential basicCredential1 =
                    // new System.Net.NetworkCredential("fitnesstrackerorange21@gmail.com", "googlesucks14");
                    client.EnableSsl = true;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = basicCredential1;
                    try
                    {
                        client.Send(mailMessage);
                        result = true;
                    }

                    catch (Exception ex)
                    {
                        result = false;
                        //todo logiing here
                    }
                    return result;
                }
            }
        }

    }
}
