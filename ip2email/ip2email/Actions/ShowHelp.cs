using IP2Email.Classes;
using IP2Email.Helpers;
using IP2Email.Interfaces;
using System.Collections.Generic;

namespace IP2Email.Actions
{
    internal class ShowHelp : IArgsAction
    {
        public void Do(string internetIP, List<string> localIPs, ref AppExitCodes appExitCode, AppConfig appConfig)
        {
            ConsoleHelper.ShowAppBanner();
            ConsoleHelper.ShowHelp();
        }
    }
}