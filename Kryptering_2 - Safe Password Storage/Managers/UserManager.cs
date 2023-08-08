using Kryptering_2___Safe_Password_Storage.Models;
using Kryptering_2___Safe_Password_Storage.Repositories;
using Kryptering_2___Safe_Password_Storage.Services;
using Kryptering_2___Safe_Password_Storage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.Managers
{
    internal class UserManager : IUserManager
    {
        private readonly ISaltService saltService;
        private readonly IHashService hashService;
        private readonly IGenericRepository<User> userRepository;
        private readonly IPasswordRepository passwordRepository;

        public UserManager(
            ISaltService saltService,
            IHashService hashService,
            IGenericRepository<User> userRepository,
            IPasswordRepository passwordRepository
            )
        {
            this.saltService = saltService;
            this.hashService = hashService;
            this.userRepository = userRepository;
            this.passwordRepository = passwordRepository;
        }
        public User Create(string username, string password)
        {
            // Validating input
            if (username == null)
            {
                throw new ArgumentNullException("Username is null");
            }
            if (password == null)
            {
                throw new ArgumentNullException("Password is null");
            }

            // Get salt value
            string salt = saltService.GenerateSalt();
            User user = new User( username, salt );
            User addedUser = userRepository.Add(user);

            // Hash password with salt value
            byte[] passwordHashedBytes = hashService.HashPassword(password, salt);
            string passwordHashed = Convert.ToBase64String( passwordHashedBytes );

            // Create password connected to user and save in data source
            Password createdPassword = new Password(passwordHashed, addedUser.Id);
            passwordRepository.Add(createdPassword);

            return addedUser;
        }

        public User[] GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
