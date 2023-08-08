using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Models
{
    internal class Password : BaseModel
    {
        public string PasswordHash { get; set; }
        public DateTime Created { get; set; }
        public object UserId { get; set; }

        /// <summary>
        /// Construct for password
        /// </summary>
        /// <param name="passwordHash">The hashed password</param>
        /// <param name="userId">The user the password is connected to</param>
        public Password(string passwordHash, object userId)
        {
            if(passwordHash == null)
            {
                throw new ArgumentNullException("passwordHash", "Password cannot be created without a PasswordHash");
            }
            if (userId == null)
            {
                throw new ArgumentNullException("userId", "Password cannot be created without a UserId");
            }

            PasswordHash = passwordHash;
            UserId = userId;
            Created = DateTime.Now;
        }
    }
}
