using Kryptering_3___Symmetric_Encryption.Enums;
using Kryptering_3___Symmetric_Encryption.Services;
using Kryptering_3___Symmetric_Encryption.Services.Interfaces;
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
        public string EncryptMessage(string msg, EncryptionType encryptionType )
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                throw new ArgumentNullException(nameof(msg));
            }

            if(msg.Contains(' '))
            {
                throw new ArgumentException("Message cannot contain whitespace", nameof(msg));
            }

            string encryptedMsg = cryptoService.Encrypt(msg);

            return encryptedMsg;
        }

        /// <summary>
        /// Encrypts a string and returns the encrypted string aswell as the string in Hexidecimal
        /// </summary>
        /// <param name="msg">Message to be encrypted</param>
        /// <param name="encryptAsHex">Returns encrypted message as Hexidecimal</param>
        /// <returns>The encrypted message</returns>
        public string EncryptMessage(string msg, EncryptionType encryptionType, out string encryptAsHex)
        {
            string encryptedMsg = EncryptMessage(msg, encryptionType);
            encryptAsHex = hexConverterService.Convert(encryptedMsg);
            return encryptedMsg;
        }
    }
}
