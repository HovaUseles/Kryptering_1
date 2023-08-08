using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Repositories
{
    internal class MockPasswordRepository : MockGenericRepository<Password>, IPasswordRepository
    {
        public MockPasswordRepository()
        {
        }
        public Password GetUserActivePassword(User user)
        {
            IEnumerable<Password> usersPasswords = MockData.Where(p => p.UserId == user.Id);
            if(usersPasswords.Any() == false) 
            {
                Exception ex = new Exception("User has no passwords");
                ex.Data.Add("User", user);
                throw ex;
            }
            return usersPasswords.OrderByDescending(p => p.Created).FirstOrDefault();
        }
    }
}
