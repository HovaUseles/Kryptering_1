using Kryptering_3___Symmetric_Encryption.Enums;
using Kryptering_3___Symmetric_Encryption.GUI.Interfaces;
using Kryptering_3___Symmetric_Encryption.GUI.Views.Encrypter;
using Kryptering_3___Symmetric_Encryption.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.GUI.Controllers
{
    internal static class EncrypterController
    {
        public static EncryptionManager encryptionManager { get; set; }

        public static IViewable Index()
        {
            return new EncrypterIndexView();
        }

        public static IViewable EncryptMessage(string message, EncryptionType? encryptionType)
        {
            if (encryptionType == null)
            {
                return new EncryptMessageView();
            }
            string key;
            string iv;
            string messageAsHex;

            string encryptedMessage = encryptionManager.EncryptMessage(message, (EncryptionType)encryptionType, out key, out iv, out messageAsHex);
            return new ShowEncryptedMessageView(encryptedMessage, messageAsHex, key, iv);
        }

        public static IViewable DecryptMessage(string encryptedMessage, EncryptionType encryptionType, string key, string iv)
        {
            string decryptedMessage = encryptionManager.DecryptMessage(encryptedMessage, encryptionType, key, iv);
            return new ShowDecryptedMessageView(decryptedMessage);
        }
    }
}
