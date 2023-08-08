using Kryptering_2___Safe_Password_Storage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Services
{
    internal class SingleHashService : IHashService
    {
        public byte[] HashPassword(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            byte[] combinedBytes = MixPasswordAndSalt(passwordBytes, saltBytes);

            return HashBytes(combinedBytes);
        }

        /// <summary>
        /// Mixing SaltBytes into PasswordBytes to create a unique Password hash
        /// </summary>
        /// <param name="passwordBytes">The password bytes</param>
        /// <param name="saltBytes">The salt value bytes</param>
        /// <returns>The mixed byte array</returns>
        private byte[] MixPasswordAndSalt(byte[] passwordBytes, byte[] saltBytes) 
        {
            return passwordBytes.Concat(saltBytes).ToArray();
        }

        /// <summary>
        /// Hashing data with SHA 512
        /// </summary>
        /// <param name="bytes">The bytes to be hashed</param>
        /// <returns>The hashed bytes</returns>
        protected byte[] HashBytes(byte[] bytes)
        {
            return SHA512.HashData(bytes);
        }
    }
}
