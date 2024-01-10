using JordanInsider.Core.DTO;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JordanInsider.API.Settings;
using MailKit.Net.Smtp;
using JordanInsider.Core.Service;

namespace JordanInsider.Infra.Service
{
    public class EmailService:IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }
        public void SendEmail(SendEmailDTO emailDto)
        {
            var email = new MimeMessage
            {
                Subject = emailDto.Subject,
                To = { MailboxAddress.Parse(emailDto.To) },
                Body = new TextPart(TextFormat.Html)
                {
                    Text = @"<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            background-color: #ffffff;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
      
        p {
            color: #555;
        }
    </style>
</head>
<body>
    <div class='container'>
        <p>" + emailDto.PlainText + "</p></div></body></html>"
                },
                From = { MailboxAddress.Parse(_emailConfig.From) }
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
