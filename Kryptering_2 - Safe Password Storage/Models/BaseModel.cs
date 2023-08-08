using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Models
{
    /// <summary>
    /// Abstract super class for all Models
    /// </summary>
    internal abstract class BaseModel
    {
        /// <summary>
        /// Identifier for the model. 
        /// </summary>
        public object Id { get; set; }
    }
}
