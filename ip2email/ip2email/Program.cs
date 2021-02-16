using System;

namespace ip2email
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IP2Email ip2Email = new IP2Email(args);
            Environment.ExitCode = Convert.ToUInt16(ip2Email.ExitCode);
        }
    }
}