using IP2Email.Helpers;
using IP2Email.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace IP2Email.Classes
{
    internal class SendMail : IArgsAction
    {
        private void SendByEmail(AppConfig config, string ip)
        {
            MailMessage message = new MailMessage(from: new MailAddress(config.SenderEmail, TextHelper.SenderDisplayName),
                                                    to: new MailAddress(config.RecipientEmail))
            {
                Subject = TextHelper.EmailSubject,
                Body = $"{TextHelper.EmailBody}: {ip}",
                IsBodyHtml = false
            };

            SmtpClient smtp = new SmtpClient(config.EmailServer, Convert.ToInt16(config.EmailServerPort))
            {
                Credentials = new NetworkCredential(config.SenderEmail, config.SenderPassword),
                EnableSsl = true
            };

            smtp.Send(message);
        }

        public void Do(string internetIP, List<string> localIPs, ref AppExitCodes appExitCode, AppConfig appConfig)
        {
            ConsoleHelper.ShowAppBanner();

            if (appConfig.IsConfigured)
            {
                try
                {
                    SendByEmail(appConfig, internetIP);
                    ConsoleHelper.EmailSend(senderEmail: appConfig.SenderEmail, recipientEmail: appConfig.RecipientEmail);
                }
                catch (Exception ex)
                {
                    ConsoleHelper.EmailSendException(exception: ex, senderEmail: appConfig.SenderEmail, recipientEmail: appConfig.RecipientEmail);
                    appExitCode = AppExitCodes.EmailSendException;
                }
            }
            else
            {
                ConsoleHelper.NotSetMailData();
                appExitCode = AppExitCodes.SetMailDataException;
            }
        }
    }
}