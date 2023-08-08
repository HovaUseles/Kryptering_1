using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Services.Interfaces
{
    /// <summary>
    /// Responsible for Hashing
    /// </summary>
    internal interface IHashService
    {
        /// <summary>
        /// Hashing a password with a salt
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <param name="salt">The salt value to include in the hash</param>
        /// <returns>Hashed data</returns>
        public byte[] HashPassword(string password, string salt);

        protected byte[] HashData(byte[] data);
    }
}
