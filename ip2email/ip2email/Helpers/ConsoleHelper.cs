using System;
using System.Collections.Generic;

namespace IP2Email.Helpers
{
    internal static class ConsoleHelper
    {
        internal static void EmailSend(string senderEmail, string recipientEmail)
        {
            Console.WriteLine($"The email from {senderEmail} to {recipientEmail} was sent successfully.");
        }

        internal static void EmailSendException(Exception exception, string senderEmail, string recipientEmail)
        {
            Console.WriteLine($"Failed to send message from {senderEmail} to {recipientEmail}.");
            Console.WriteLine($"Exception description: {exception.Message}.");
        }

        internal static void EmailSettingsSave(bool state)
        {
            Console.WriteLine(state == true ? "Excellent! Now all settings successfully saved." : "Something went wrong! Couldn't save settings.");
        }

        internal static void NotSetMailData()
        {
            Console.WriteLine("A email cannot be sent without initial settings.");
            Console.WriteLine("Usage: \"ip2email -config\" to configure email settings.");
        }

        internal static void SetMailData()
        {
            Console.WriteLine("WARNING: DO NOT ENTER HERE YOUR CURRENT EMAIL'S LOGIN AND PASSWORD!");
            Console.WriteLine("IT'S NOT SAFE! CREATE NEW EMAIL ACCOUNT WITH A STRONG AND RANDOM PASSWORD.");
            Console.WriteLine();
            Console.WriteLine("Specify the following parameters to send an email your PC IP addresses notifications:");
        }

        internal static string SetOption(string option)
        {
            Console.Write(option);
            return Console.ReadLine();
        }

        internal static void ShowAppBanner()
        {
            Console.WriteLine();
            Console.WriteLine("IP2Email sends an email with your public IP address got by https://ifconfig.me");
            Console.WriteLine("Copyright (C) 2020 — 2021, Inestic");
            Console.WriteLine("https://github.com/inestic/ip2email");
            Console.WriteLine();
        }

        internal static void ShowHelp()
        {
            Console.WriteLine("Usage: IP2Email [-config] | [-send]");
            Console.WriteLine();
            Console.WriteLine("-config   Configure and temporary save email recipient & sender settings.");
            Console.WriteLine("-send     Send your public IP address within configured email settings.");
            Console.WriteLine();
            Console.WriteLine("IP2Email returns a zero (0) status on success. If the return code is a nonzero, an error has occurred.");
        }

        internal static void ShowIPs(string internetIP, List<string> localIPs)
        {
            Console.WriteLine($"Public IP . . . . . : {internetIP}");
            localIPs.ForEach(ip => Console.WriteLine($"Local IP. . . . . . : {ip}"));
            Console.WriteLine();
        }
    }
}