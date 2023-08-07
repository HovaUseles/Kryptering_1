using Kryptering_1___Hashing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_1___Hashing.Managers.Interfaces
{
    /// <summary>
    /// Interface for Hash manager class that is responsible for passing Hash related request to Services
    /// </summary>
    internal interface IHashManager
    {
        /// <summary>
        /// Hash a string
        /// </summary>
        /// <param name="stringToHash">string to hashed</param>
        /// <param name="hashingMethod">Choose one of the available hashing methods</param>
        /// <returns>The byte value of the hashed string</returns>
        public byte[] Hash(string stringToHash, HashingMethods hashingMethod);

        /// <summary>
        /// Hash a string with a specific Key using HMAC
        /// </summary>
        /// <param name="stringToHash">string to hashed</param>
        /// <param name="key">The key to be used for the hashing</param>
        /// <param name="hashingMethod">Choose one of the available hashing methods</param>
        /// <returns>The byte value of the hashed string and key</returns>
        public byte[] HashWithKey(string stringToHash, string key, HashingMethods hashingMethod);
    }
}
