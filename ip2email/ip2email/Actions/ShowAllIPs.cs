using IP2Email.Helpers;
using IP2Email.Interfaces;
using System.Collections.Generic;

namespace IP2Email.Classes
{
    internal class ShowAllIPs : IArgsAction
    {
        public void Do(string internetIP, List<string> localIPs, ref AppExitCodes appExitCode, AppConfig appConfig)
        {
            ConsoleHelper.ShowAppBanner();
            ConsoleHelper.ShowIPs(internetIP, localIPs);
        }
    }
}