using Kryptering_4___Asymmetric_Encryption_Receiver.Services;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_4___Asymmetric_Encryption_Receiver.Managers
{
    /// <summary>
    /// Responsible for handling decryption related actions
    /// </summary>
    internal class DecryptionManager
    {
        private string privateKeyPath { get; }
        private string publicKeyPath { get; }

        private readonly IDecryptionService decryptionService;

        public DecryptionManager(IDecryptionService decryptionService)
        {
            this.decryptionService = decryptionService;

            // Setting paths
            publicKeyPath = "c:\\temp\\publickey.xml"; // Creating keys to temp folder
            privateKeyPath = "c:\\temp\\privatekey.xml"; // Creating keys to temp folder
        }

        public string GenKeys()
        {
            decryptionService.GenNewKeys(publicKeyPath, privateKeyPath);
            return publicKeyPath;
        }

        public string DecryptMessage(string messageToDecrypt)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(messageToDecrypt))
            {
                throw new ArgumentNullException(nameof(messageToDecrypt));
            }

            //byte[] bytesToDecrypt = Encoding.UTF8.GetBytes(messageToDecrypt);
            byte[] bytesToDecrypt = Convert.FromBase64String(messageToDecrypt);
            byte[] decryptedBytes = decryptionService.Decrypt(bytesToDecrypt, privateKeyPath);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
