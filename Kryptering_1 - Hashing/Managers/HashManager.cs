using Kryptering_1___Hashing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_1___Hashing.Managers
{
    internal class HashManager : IHashManager
    {
        private HasherService hasherService { get; }
        public HashManager()
        {
            hasherService = new HasherService();
        }
        public byte[] Hash(string stringToHash, HashingMethods hashingMethod)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(stringToHash);
            switch (hashingMethod)
            {
                case HashingMethods.MD5:
                    return hasherService.HashMD5(inputBytes);
                case HashingMethods.SHA1:
                    return hasherService.HashSHA1(inputBytes);
                case HashingMethods.SHA256:
                default:
                    return hasherService.HashSHA256(inputBytes);
                case HashingMethods.SHA512:
                    return hasherService.HashSHA512(inputBytes);
            }
        }


        public byte[] HashWithKey(string stringToHash, string key, HashingMethods hashingMethod)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(stringToHash);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            switch (hashingMethod)
            {
                case HashingMethods.MD5:
                    return hasherService.HashMD5WithKey(inputBytes, keyBytes);
                case HashingMethods.SHA1:
                    return hasherService.HashSHA1WithKey(inputBytes, keyBytes);
                case HashingMethods.SHA256:
                default:
                    return hasherService.HashSHA256WithKey(inputBytes, keyBytes);
                case HashingMethods.SHA512:
                    return hasherService.HashSHA512WithKey(inputBytes, keyBytes);
            }
        }
    }
}
