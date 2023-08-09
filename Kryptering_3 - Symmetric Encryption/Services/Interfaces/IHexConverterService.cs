using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.Services.Interfaces
{
    /// <summary>
    /// Service for converting values to hexidecimal
    /// </summary>
    internal interface IHexConverterService
    {
        /// <summary>
        /// Converts a string to a Hexidecimal string and returns it
        /// </summary>
        /// <param name="stringToConvert">The string to convert</param>
        /// <returns>The hex string</returns>
        public string Convert(string stringToConvert);

        /// <summary>
        /// Converts a byte array to a Hexidecimal string and returns it
        /// </summary>
        /// <param name="bytesToConvert">The byte array to convert</param>
        /// <returns>The hex string</returns>
        public string Convert(byte[] bytesToConvert);
    }
}
