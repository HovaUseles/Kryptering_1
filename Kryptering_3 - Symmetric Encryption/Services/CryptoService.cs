using Azure;
using Kryptering_3___Symmetric_Encryption.Enums;
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
        public string Decrypt(string stringToDecrypt, EncryptionType encryptionType)
        {
            
        }

        public string Encrypt(string stringToEncrypt, EncryptionType encryptionType)
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
            return Encrypt(bytesToEncrypt, encryptionType);
        }

        public string Encrypt(byte[] bytesToEncrypt, EncryptionType encryptionType)
        {
            byte[] key = new byte[32];
            byte[] cipherOutput = new byte[bytesToEncrypt.Length]; 

            // Evaluate encryption type
            switch (encryptionType)
            {
                case EncryptionType.Des:
                    DES des = DES.Create(key);
                    des.Encrypt(nonce, bytesToEncrypt, ciphertext, tag);
                    break;
                case EncryptionType.TripleDes:
                    TripleDES tripleDES = TripleDES.Create(key)
                    tripleDES.Encrypt(nonce, bytesToEncrypt, ciphertext, tag);
                    break;
                case EncryptionType.Aes:
                    AesGcm aesGcm = new AesGcm(key);
                    byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
                    byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize];

                    aesGcm.Encrypt(nonce, bytesToEncrypt, cipherOutput, tag);
                    break;
            }

            return Encoding.UTF8.GetString(cipherOutput);
        }
    }
}
