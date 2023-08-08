using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Repositories
{
    internal interface IPasswordRepository : IGenericRepository<Password>
    {
        public Password GetUserActivePassword(User user);
    }
}
