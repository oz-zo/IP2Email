namespace IP2Email.Classes
{
    internal enum AppExitCodes
    {
        Success = 0,
        LocalIpException = 10,
        InternetIpException = 20,
        SaveSettingsException = 30,
        SetMailDataException = 40,
        EmailSendException = 50
    }
}