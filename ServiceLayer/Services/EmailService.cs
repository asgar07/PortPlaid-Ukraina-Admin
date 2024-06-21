using DomainLayer.Entities;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MailKit.Net.Smtp;

namespace ServiceLayer.Services
{
    public class EmailService:IEmailService
    {
        private readonly IWebHostEnvironment _env;
        public EmailService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task ConfirmEmail(AppUser appUser, string token)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("PortPlaid", "pointcutbarbershop01@gmail.com"));
            message.To.Add(new MailboxAddress(appUser.UserName, appUser.Email));
            message.Subject = "Confirm Email";
            string emailbody = string.Empty;

            using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Confirm.html")))
            {
                emailbody = streamReader.ReadToEnd();
            }

            emailbody = emailbody.Replace("{{code}}", $"{token}").Replace("{{fullname}}", $"{appUser.UserName}");
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("pointcutbarbershop01@gmail.com", "okqwhfhtbljwjlun");
            smtp.Send(message);
            smtp.Disconnect(true);
        }

    }
}
