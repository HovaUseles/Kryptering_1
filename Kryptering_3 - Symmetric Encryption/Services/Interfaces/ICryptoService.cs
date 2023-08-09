using Kryptering_3___Symmetric_Encryption.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.Services
{
    /// <summary>
    /// Service for encrypting and decrypting
    /// </summary>
    internal interface ICryptoService
    {
        /// <summary>
        /// Encrypt a string and returns the encrypted value
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt</param>
        /// <returns>Encrypted string</returns>
        public string Encrypt(string stringToEncrypt, EncryptionType encryptionType);

        /// <summary>
        /// Encrypt a byte array and returns the encrypted value
        /// </summary>
        /// <param name="bytesToEncrypt">The byte array to encrypt</param>
        /// <returns>Encrypted string</returns>
        public string Encrypt(byte[] bytesToEncrypt, EncryptionType encryptionType);

        /// <summary>
        /// Decrypt a string and returns the decrypted value
        /// </summary>
        /// <param name="bytesToEncrypt">The byte array to decrypt</param>
        /// <returns>Decrypted string</returns>
        public string Decrypt(string stringToDecrypt, EncryptionType encryptionType);
    }
}
