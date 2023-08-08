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

        /// <summary>
        /// Login as a user via username and password
        /// </summary>
        /// <param name="username">Username of the user to login as</param>
        /// <param name="password">Password of the user to login as</param>
        /// <returns>The logged in user</returns>
        public User LoginAsUser(string username, string password);

        /// <summary>
        /// Change the password of a user
        /// </summary>
        /// <param name="user">The user changing the on</param>
        /// <param name="oldPassword">The old password for validation</param>
        /// <param name="newPassword">The  new password to change to</param>
        public void ChangePassword(User user, string oldPassword,  string newPassword);
    }
}
