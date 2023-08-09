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
        private static EncryptionManager encryptionManager { get; set; }
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
            string encryptedMessage = encryptionManager.EncryptMessage(message, (EncryptionType)encryptionType);
            return new ShowEncryptedMessageView(encryptedMessage);
        }

        public static IViewable DecryptMessage(string message, EncryptionType encryptionType)
        {
            string decryptedMessage = encryptionManager.DecryptMessage(message, encryptionType);
            return new ShowEncryptedMessageView(encryptedMessage);
        }
    }
}
