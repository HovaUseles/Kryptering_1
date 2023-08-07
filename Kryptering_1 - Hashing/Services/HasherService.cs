using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_1___Hashing
{
    /// <summary>
    /// Responsible for hashing logic
    /// </summary>
    internal class HasherService
    {
        /// <summary>
        /// Hashing with MD5
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <returns>Hashed data</returns>
        public byte[] HashMD5(byte[] data)
        {
            return MD5.HashData(data);
        }

        /// <summary>
        /// Hashing with SHA 1
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <returns>Hashed data</returns>
        public byte[] HashSHA1(byte[] data)
        {
            return SHA1.HashData(data);
        }

        /// <summary>
        /// Hashing with SHA 256
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <returns>Hashed data</returns>
        public byte[] HashSHA256(byte[] data)
        {
            return SHA256.HashData(data);
        }

        /// <summary>
        /// Hashing with SHA 512
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <returns>Hashed data</returns>
        public byte[] HashSHA512(byte[] data)
        {
            return SHA512.HashData(data);
        }

        /// <summary>
        /// Message based hashing with MD5
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <param name="key">HMAC Key</param>
        /// <returns>Hashed data</returns>
        public byte[] HashMD5WithKey(byte[] data, byte[] key) 
        {
            return HMACMD5.HashData(key, data);
        }

        /// <summary>
        /// Message based hashing with SHA1
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <param name="key">HMAC Key</param>
        /// <returns>Hashed data</returns>
        public byte[] HashSHA1WithKey(byte[] data, byte[] key) 
        {
            return HMACSHA1.HashData(key, data);
        }

        /// <summary>
        /// Message based hashing with SHA256
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <param name="key">HMAC Key</param>
        /// <returns>Hashed data</returns>
        public byte[] HashSHA256WithKey(byte[] data, byte[] key) 
        { 
            return HMACSHA256.HashData(key, data);
        }

        /// <summary>
        /// Message based hashing with SHA512
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <param name="key">HMAC Key</param>
        /// <returns>Hashed data</returns>
        public byte[] HashSHA512WithKey(byte[] data, byte[] key) 
        {
            return HMACSHA512.HashData(key, data);
        }
    }
}
