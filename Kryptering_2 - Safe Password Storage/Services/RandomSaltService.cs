using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Services
{
    internal class RandomSaltService : ISaltService
    {
        public string GenerateSalt()
        {
            Random random = new Random();
            return random.Next(1000, 10000).ToString();
        }
    }
}
