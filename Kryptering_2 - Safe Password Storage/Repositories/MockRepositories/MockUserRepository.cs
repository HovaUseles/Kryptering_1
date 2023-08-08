using Kryptering_2___Safe_Password_Storage.Models;
using Kryptering_2___Safe_Password_Storage.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Repositories
{
    internal class MockUserRepository : MockGenericRepository<User>, IUserRepository
    {
        public User GetByUsername(string username)
        {
            return MockData.FirstOrDefault(m => m.Username == username);
        }
    }
}
