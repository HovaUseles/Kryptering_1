using Kryptering_4___Asymmetric_Encryption_Receiver.Services;
using System.Text;

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

        /// <summary>
        /// Constructor, takes an inject Decryption service
        /// </summary>
        /// <param name="decryptionService">Injected decryption service</param>
        public DecryptionManager(IDecryptionService decryptionService)
        {
            this.decryptionService = decryptionService;

            // Setting paths
            publicKeyPath = "c:\\temp\\publickey.xml"; // Creating keys to temp folder
            privateKeyPath = "c:\\temp\\privatekey.xml"; // Creating keys to temp folder
        }

        /// <summary>
        /// Generates encryption keys
        /// </summary>
        /// <returns>The path of the generated public key</returns>
        public string GenKeys()
        {
            decryptionService.GenNewKeys(publicKeyPath, privateKeyPath);
            return publicKeyPath;
        }

        /// <summary>
        /// Decrypts a message using the stored public and private keys
        /// </summary>
        /// <param name="messageToDecrypt">The encrypted message</param>
        /// <returns>The decrypting message</returns>
        /// <exception cref="ArgumentNullException"></exception>
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
