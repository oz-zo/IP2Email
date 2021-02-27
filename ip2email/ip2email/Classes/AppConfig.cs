using IP2Email.Helpers;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IP2Email.Classes
{
    public class AppConfig
    {
        internal AppConfig()
        {
            SetIsConfiguredState();
        }

        internal string EmailServer { get => DecodeFromRegistry("ESE"); set => EncodeToRegistry("ESE", value); }
        internal string EmailServerPort { get => DecodeFromRegistry("ESP"); set => EncodeToRegistry("ESP", value); }
        internal bool IsConfigured { get; set; }
        internal string RecipientEmail { get => DecodeFromRegistry("REM"); set => EncodeToRegistry("REM", value); }
        internal string SenderEmail { get => DecodeFromRegistry("SEM"); set => EncodeToRegistry("SEM", value); }
        internal string SenderPassword { get => DecodeFromRegistry("SEP"); set => EncodeToRegistry("SEP", value); }

        private string DecodeFromRegistry(string regKeyName)
        {
            string plaintext = null;

            try
            {
                byte[] regKeyValue = Registry.CurrentUser.OpenSubKey(TextHelper.RegistryKeySoftware, false)
                                                         .OpenSubKey(TextHelper.RegistryKeyAuthor)
                                                         .OpenSubKey(TextHelper.RegistryAppName)
                                                         .GetValue(regKeyName) as byte[];

                if (regKeyValue != null)
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = Encoding.UTF8.GetBytes(TextHelper.SecurityKey);
                        aes.IV = Encoding.UTF8.GetBytes(TextHelper.SecurityKey);

                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                        using (MemoryStream msDecrypt = new MemoryStream(regKeyValue))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {
                                    plaintext = srDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return plaintext;
        }

        private void EncodeToRegistry(string regKeyName, string regKeyValue)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(TextHelper.SecurityKey);
                aes.IV = Encoding.UTF8.GetBytes(TextHelper.SecurityKey);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(regKeyValue);
                        }
                    }

                    Registry.CurrentUser.OpenSubKey(TextHelper.RegistryKeySoftware, true)
                                .CreateSubKey(TextHelper.RegistryKeyAuthor, true)
                                .CreateSubKey(TextHelper.RegistryAppName, true)
                                .SetValue(regKeyName, msEncrypt.ToArray());
                }
            }
        }

        private void SetIsConfiguredState()
        {
            IsConfigured = (SenderEmail == null || SenderPassword == null
                                                || RecipientEmail == null
                                                || EmailServer == null
                                                || EmailServerPort == null) ? false : true;
        }
    }
}