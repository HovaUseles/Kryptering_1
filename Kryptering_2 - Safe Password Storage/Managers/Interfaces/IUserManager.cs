using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Managers
{
    /// <summary>
    /// Responsible for transfering and manipulating data from GUI to the Data access
    /// </summary>
    internal interface IUserManager
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns>The Created User</returns>
        public User Create(string username, string password);

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">The id of the user to get</param>
        /// <returns>The received user</returns>
        public User GetById(object id);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>All users</returns>
        public User[] GetAll();
    }
}
