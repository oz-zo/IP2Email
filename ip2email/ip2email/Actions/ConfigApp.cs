using IP2Email.Classes;
using IP2Email.Helpers;
using IP2Email.Interfaces;
using System.Collections.Generic;

namespace IP2Email.Actions
{
    internal class ConfigApp : IArgsAction
    {
        public void Do(string internetIP, List<string> localIPs, ref AppExitCodes appExitCode, AppConfig appConfig)
        {
            try
            {
                ConsoleHelper.ShowAppBanner();
                ConsoleHelper.SetMailData();
                appConfig.RecipientEmail = ConsoleHelper.SetOption("Recipient email address . . . : ");
                appConfig.SenderEmail = ConsoleHelper.SetOption("Sender email address. . . . . : ");
                appConfig.SenderPassword = ConsoleHelper.SetOption("Sender email password . . . . : ");
                appConfig.EmailServer = ConsoleHelper.SetOption("Sender SMTP Server (for gmail.com use smtp.gmail.com) . . . : ");
                appConfig.EmailServerPort = ConsoleHelper.SetOption("Sender SMTP Port (for gmail.com use 587). . . . . . . . . . : ");
                ConsoleHelper.EmailSettingsSave(true);
                appConfig.IsConfigured = true;
            }
            catch
            {
                ConsoleHelper.EmailSettingsSave(false);
                appExitCode = AppExitCodes.SaveSettingsException;
            }
        }
    }
}