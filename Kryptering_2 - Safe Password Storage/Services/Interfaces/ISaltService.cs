using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Services
{
    /// <summary>
    /// Responsible for Salt values and manipulation
    /// </summary>
    internal interface ISaltService
    {
        /// <summary>
        /// Generates a salt value
        /// </summary>
        /// <returns>The generated salt value</returns>
        public string GenerateSalt();
    }
}
