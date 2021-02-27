using IP2Email.Classes;
using System.Collections.Generic;

namespace IP2Email.Interfaces
{
    internal interface IArgsAction
    {
        void Do(string internetIP, List<string> localIPs, ref AppExitCodes appExitCode, AppConfig appConfig);
    }
}