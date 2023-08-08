using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Models
{
    /// <summary>
    /// Data model Representing a user in the application
    /// </summary>
    internal class User : BaseModel
    {
        public string Username { get; set; }
        public string Salt { get; set; }
        public Password[] Passwords { get; set; }

        /// <summary>
        /// Constructor for User model
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="salt">Salt used for password hash</param>
        public User(string username, string salt) 
        {
            Username = username;
            Salt = salt;
        }
    }
}
