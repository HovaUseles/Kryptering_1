using Kryptering_3___Symmetric_Encryption.Enums;
using Kryptering_3___Symmetric_Encryption.Services;
using Kryptering_3___Symmetric_Encryption.Services.Interfaces;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.Managers
{
    internal class EncryptionManager
    {
        private readonly ICryptoService cryptoService;
        private readonly IHexConverterService hexConverterService;

        public EncryptionManager(
            ICryptoService cryptoService,
            IHexConverterService hexConverterService
            )
        {
            this.cryptoService = cryptoService;
            this.hexConverterService = hexConverterService;
        }

        /// <summary>
        /// Encrypts a string and returns the encrypted string
        /// </summary>
        /// <param name="msg">Message to be encrypted</param>
        /// <param name="encryptionType">The type of encryption</param>
        /// <returns>The encrypted message</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public string EncryptMessage(string msg, EncryptionType encryptionType, out string key, out string iv)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                throw new ArgumentNullException(nameof(msg));
            }

            if(msg.Contains(' '))
            {
                throw new ArgumentException("Message cannot contain whitespace", nameof(msg));
            }

            byte[] keyBytes;
            byte[] ivBytes;
            string encryptedMsg = cryptoService.Encrypt(msg, encryptionType, out keyBytes, out ivBytes);

            // Converting key and iv to Base 64 string for cleaner displaying
            key = Convert.ToBase64String(keyBytes);
            iv = Convert.ToBase64String(ivBytes);

            return encryptedMsg;
        }

        /// <summary>
        /// Encrypts a string and returns the encrypted string aswell as the string in Hexidecimal
        /// </summary>
        /// <param name="msg">Message to be encrypted</param>
        /// <param name="encryptAsHex">Returns encrypted message as Hexidecimal</param>
        /// <returns>The encrypted message</returns>
        public string EncryptMessage(string msg, EncryptionType encryptionType, out string key, out string iv, out string encryptAsHex)
        {
            string encryptedMsg = EncryptMessage(msg, encryptionType, out key, out iv);
            encryptAsHex = hexConverterService.Convert(encryptedMsg);
            return encryptedMsg;
        }

        /// <summary>
        /// Decrypts an encrypted string return the decrypted message
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message to decrypt</param>
        /// <param name="decryptionType">The type of decryption to use</param>
        /// <returns>The decrypted string</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string DecryptMessage(string encryptedMessage,  EncryptionType decryptionType, string key, string iv)
        {
            // Validating input
            if (string.IsNullOrWhiteSpace(encryptedMessage))
            {
                throw new ArgumentNullException(nameof(encryptedMessage));
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrWhiteSpace(iv))
            {
                throw new ArgumentNullException(nameof(iv));
            }

            // Convert key and iv strings to byte array
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] ivBytes = Convert.FromBase64String(iv);

            string decryptedMsg = cryptoService.Decrypt(encryptedMessage, decryptionType, keyBytes, ivBytes);

            return decryptedMsg;
        }
    }
}
