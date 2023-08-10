using Kryptering_3___Symmetric_Encryption.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.Services
{
    internal class HexConverterService : IHexConverterService
    {
        public string Convert(string stringToConvert)
        {
            return Convert(Encoding.UTF8.GetBytes(stringToConvert));
        }

        public string Convert(byte[] bytesToConvert)
        {
            return BitConverter.ToString(bytesToConvert);
        }
    }
}
