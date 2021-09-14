﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public class SMTP : ISMTP
    {
        private readonly string appName = "";
        private readonly string appLocalURL = "";
        private readonly string smtpServer = "";
        private readonly string from = "";
        private readonly string pass = "";

        private readonly IConfiguration _configuration;
        private readonly SmtpClient client;

        public SMTP(IConfiguration configuration)
        {
            _configuration = configuration;
            appName = _configuration["AppSettings:AppName"];
            appLocalURL = _configuration["AppSettings:AppLocalURL"];
            smtpServer = _configuration["CredentialsSMTP:Server"];
            from = _configuration["CredentialsSMTP:Login"];
            pass = _configuration["CredentialsSMTP:Password"];

            client = new SmtpClient(smtpServer);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;
        }

        public void SendSignUpRequest(string toEmail, string tokenVerified)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(from, appName);
            mail.To.Add(toEmail);
            mail.Subject = "Підтвердження реєстрації в " + appName;
            mail.Body = "<a href='" + appLocalURL + "account/confirm_email?email=" + toEmail + "&token=" + tokenVerified + "' class='myButton'>Confirm Email</a>";
            mail.IsBodyHtml = true;

            client.Send(mail);
        }
    }
}
 