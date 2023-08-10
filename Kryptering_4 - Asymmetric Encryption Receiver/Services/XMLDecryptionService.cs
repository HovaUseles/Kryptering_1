using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kryptering_4___Asymmetric_Encryption_Receiver.Services
{
    internal class XMLDecryptionService : IDecryptionService
    {
        public byte[] Decrypt(byte[] bytesToDecrypt, string privateKeyPath)
        {
            byte[] decryptedBytes;

            // Check if private key exist
            if (!File.Exists(privateKeyPath))
            {
                throw new ArgumentException("No private key exist on path", nameof(privateKeyPath));
            }

            // Decrypt message
            using (var rsa = RSA.Create())
            {
                rsa.FromXmlString(File.ReadAllText(privateKeyPath)); // Get private key
                decryptedBytes = rsa.Decrypt(bytesToDecrypt, RSAEncryptionPadding.Pkcs1);
            }

            return decryptedBytes;
        }

        public void GenNewKeys(string publicKeyPath, string privateKeyPath)
        {
            // Validate inputs
            if(string.IsNullOrWhiteSpace(publicKeyPath))
            {
                throw new ArgumentNullException(nameof(publicKeyPath));
            }
            if(string.IsNullOrWhiteSpace(privateKeyPath))
            {
                throw new ArgumentNullException(nameof(privateKeyPath));
            }

            using (var rsa = RSA.Create(2048))
            {
                // If file exist, delete it
                if (File.Exists(privateKeyPath))
                {
                    File.Delete(privateKeyPath);
                }

                if (File.Exists(publicKeyPath))
                {
                    File.Delete(publicKeyPath);
                }

                var publicKeyDirectory = Path.GetDirectoryName(publicKeyPath);
                var privateKeyDirectory = Path.GetDirectoryName(privateKeyPath);

                // If directory does not exist, create it
                if (!Directory.Exists(publicKeyDirectory))
                {
                    Directory.CreateDirectory(publicKeyDirectory);
                }

                if (!Directory.Exists(privateKeyDirectory))
                {
                    Directory.CreateDirectory(privateKeyDirectory);
                }

                // Never do this in production
                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false)); // Public only
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));  // Both public and private
            }
        }
    }
}
