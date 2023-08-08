using Kryptering_2___Safe_Password_Storage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Services
{
    internal class PBKDF2HashService : IHashService
    {
        public byte[] HashPassword(string password, string salt)
        {
            // Settings
            int hashIterations = 500000;
            int keySize = 32;

            // input Bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            return Rfc2898DeriveBytes.Pbkdf2(passwordBytes, saltBytes, hashIterations, HashAlgorithmName.SHA512, keySize);
        }
    }
}
