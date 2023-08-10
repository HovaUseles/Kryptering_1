using Azure;
using Kryptering_3___Symmetric_Encryption.Enums;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.Services
{
    internal class CryptoService : ICryptoService
    {
        #region Decryption
        public string Decrypt(string stringToDecrypt, EncryptionType decryptionType, byte[] key, byte[] iv)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(stringToDecrypt))
            {
                throw new ArgumentNullException(nameof(stringToDecrypt));
            }
            if (stringToDecrypt.Contains(' '))
            {
                throw new ArgumentException("Encrypted message cannot contain whitespace", nameof(stringToDecrypt));
            }

            byte[] bytesToDecrypt = Convert.FromBase64String(stringToDecrypt);
            return Encrypt(bytesToDecrypt, decryptionType, out key, out iv);
        }

        public string Decrypt(byte[] bytesToDecrypt, EncryptionType decryptionType, byte[] key, byte[] iv)
        {
            // Evaluate encryption type input
            switch (decryptionType)
            {
                case EncryptionType.Des:
                    return DecryptWithDES(bytesToDecrypt, key, iv);
                case EncryptionType.TripleDes:
                    return DecryptWithTripleDES(bytesToDecrypt, key, iv);
                case EncryptionType.Aes:
                    return DecryptWithAES(bytesToDecrypt, key, iv);
                default:
                    throw new NotImplementedException($"No implementation for encryption type: {decryptionType}");
            }
        }

        /// <summary>
        /// Decrypting using DES
        /// </summary>
        /// <param name="bytesToDecrypt"></param>
        /// <returns>Decrypted string</returns>
        private string DecryptWithDES(byte[] bytesToDecrypt, byte[] key, byte[] iv)
        {
            // Creating and using decrypter and disposing it when finished
            using (DES des = DES.Create())
            {
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;

                // Build Decryter transform
                ICryptoTransform decrypter = des.CreateDecryptor(des.Key, des.IV);

                // Using to memory and crypto stream to write to output
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read))
                    {
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            return swDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Decrypting using Triple DES
        /// </summary>
        /// <param name="bytesToDecrypt"></param>
        /// <returns>Decrypted string</returns>
        private string DecryptWithTripleDES(byte[] bytesToDecrypt, byte[] key, byte[] iv)
        {
            // Creating and using decrypter and disposing it when finished
            using (TripleDES tripleDes = TripleDES.Create())
            {
                tripleDes.Padding = PaddingMode.PKCS7;
                tripleDes.Key = key;
                tripleDes.IV = iv;

                // Build Decryter transform
                ICryptoTransform decrypter = tripleDes.CreateDecryptor(tripleDes.Key, tripleDes.IV);

                // Using to memory and crypto stream to write to output
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read))
                    {
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            return swDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Decrypting using AES
        /// </summary>
        /// <param name="bytesToDecrypt"></param>
        /// <returns>Decrypted string</returns>
        private string DecryptWithAES(byte[] bytesToDecrypt, byte[] key, byte[] iv)
        {
            // Creating and using decrypter and disposing it when finished
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                // Build decryter transform
                ICryptoTransform decrypter = aes.CreateDecryptor(aes.Key, aes.IV);

                // Using to memory and crypto stream to write to output
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypter, CryptoStreamMode.Read))
                    {
                        using (StreamReader swDecrypt = new StreamReader(csDecrypt))
                        {
                            return swDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion

        #region Encryption
        public string Encrypt(string stringToEncrypt, EncryptionType encryptionType, out byte[] key, out byte[] iv)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(stringToEncrypt))
            {
                throw new ArgumentNullException(nameof(stringToEncrypt));
            }
            if (stringToEncrypt.Contains(' '))
            {
                throw new ArgumentException("Message cannot contain whitespace", nameof(stringToEncrypt));
            }

            byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(stringToEncrypt);
            return Encrypt(bytesToEncrypt, encryptionType, out key, out iv);
        }

        public string Encrypt(byte[] bytesToEncrypt, EncryptionType encryptionType, out byte[] key, out byte[] iv)
        {
            if(bytesToEncrypt == null)
            {
                throw new ArgumentNullException(nameof(bytesToEncrypt));
            }

            // Generate a random key
            byte[] generatedKey = new byte[32];
            RandomNumberGenerator.Fill(generatedKey);
            key = generatedKey;

            byte[]? cipherOutput = null;

            // Evaluate encryption type input
            switch (encryptionType)
            {
                case EncryptionType.Des:
                    using (DES des = DES.Create())
                    {
                        // Generating key and iv
                        key = des.Key;
                        iv = des.IV;
                        cipherOutput = EncryptWithDES(bytesToEncrypt, key, iv);
                    }
                    break;
                case EncryptionType.TripleDes:
                    using (TripleDES tripleDes = TripleDES.Create())
                    {
                        // Generating key and iv
                        key = tripleDes.Key;
                        iv = tripleDes.IV;
                    cipherOutput = EncryptWithTripleDES(bytesToEncrypt, key, iv);
                    }
                    break;
                case EncryptionType.Aes:
                    using (Aes aes = Aes.Create())
                    {
                        // Generating key and iv
                        key = aes.Key;
                        iv = aes.IV;
                        cipherOutput = EncryptWithAES(bytesToEncrypt, key, iv);
                    }
                    break;
                default:
                    throw new NotImplementedException($"No implementation for encryption type: {encryptionType}");
            }

            // If encryption was successful, return it
            if (cipherOutput != null || cipherOutput.Length == 0)
            {
                return Convert.ToBase64String(cipherOutput);
            }

            throw new CryptographicException("Message was not encrypted");
        }

        /// <summary>
        /// Encrypting using DES
        /// </summary>
        /// <param name="bytesToEncrypt"></param>
        /// <returns>Encrypted byte array</returns>
        private byte[] EncryptWithDES(byte[] bytesToEncrypt, byte[] key, byte[] iv)
        {
            // Creating and using encrypter and disposing it when finished
            using (DES des = DES.Create())
            {
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;

                // Build Encryter transform
                ICryptoTransform encrypter = des.CreateEncryptor(des.Key, des.IV);

                // Using to memory and crypto stream to write to output
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypter, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(bytesToEncrypt);
                        }

                        // Convert stream to byte array and return
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Encrypting using Triple DES
        /// </summary>
        /// <param name="bytesToDecrypt"></param>
        /// <returns>Encrypted byte array</returns>
        private byte[] EncryptWithTripleDES(byte[] bytesToEncrypt, byte[] key, byte[] iv)
        {
            // Creating and using encrypter and disposing it when finished
            using (TripleDES tripleDes = TripleDES.Create())
            {
                tripleDes.Padding = PaddingMode.PKCS7;
                tripleDes.Key = key;
                tripleDes.IV = iv;

                // Build Encryter transform
                ICryptoTransform encrypter = tripleDes.CreateEncryptor(tripleDes.Key, tripleDes.IV);

                // Using to memory and crypto stream to write to output
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypter, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(bytesToEncrypt);
                        }

                        // Convert stream to byte array and return
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Encrypting using AES
        /// </summary>
        /// <param name="bytesToEncrypt"></param>
        /// <returns>Encrypted byte array</returns>
        private byte[] EncryptWithAES(byte[] bytesToEncrypt, byte[] key, byte[] iv)
        {
            // Creating and using encrypter and disposing it when finished
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;

                // Build Encryter transform
                ICryptoTransform encrypter = aes.CreateEncryptor(aes.Key, aes.IV);

                // Using to memory and crypto stream to write to output
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypter, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(bytesToEncrypt);
                        }

                        // Convert stream to byte array and return
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        #endregion
    }
}
