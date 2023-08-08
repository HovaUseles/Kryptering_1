using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Repositories.Interfaces
{
    internal interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Get user with a specific username
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <returns>The user if it exist else null</returns>
        public User GetByUsername(string username);

    }
}
