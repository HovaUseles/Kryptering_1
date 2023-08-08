using Kryptering_2___Safe_Password_Storage.Models;
using Kryptering_2___Safe_Password_Storage.Repositories;
using Kryptering_2___Safe_Password_Storage.Repositories.Interfaces;
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
        private readonly IUserRepository userRepository;
        private readonly IPasswordRepository passwordRepository;

        public UserManager(
            ISaltService saltService,
            IHashService hashService,
            IUserRepository userRepository,
            IPasswordRepository passwordRepository
            )
        {
            this.saltService = saltService;
            this.hashService = hashService;
            this.userRepository = userRepository;
            this.passwordRepository = passwordRepository;
        }

        public void ChangePassword(User user, string oldPasswordInput, string newPasswordInput)
        {
            // Validate input
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null or empty");
            }
            if (string.IsNullOrEmpty(oldPasswordInput))
            {
                throw new ArgumentNullException(nameof(oldPasswordInput), "Old password cannot be null or empty");
            }
            if (string.IsNullOrEmpty(newPasswordInput))
            {
                throw new ArgumentNullException(nameof(newPasswordInput),"New password cannot be null or empty");
            }

            // Hash old password input
            byte[] oldPasswordHashedBytes = hashService.HashPassword(oldPasswordInput, user.Salt);
            string oldPasswordHashed = Convert.ToBase64String(oldPasswordHashedBytes);

            // Validate Old Password hash
            Password activePassword = passwordRepository.GetUserActivePassword(user);
            if (activePassword.PasswordHash != oldPasswordHashed)
            {
                throw new ArgumentException("Old password is incorrect");
            }

            // Hash new password input
            byte[] newPasswordHashedBytes = hashService.HashPassword(newPasswordInput, user.Salt);
            string newPasswordHashed = Convert.ToBase64String(newPasswordHashedBytes);

            // Check if password has been used before
            if(passwordRepository.GetAllUserPasswords(user).Any(p => p.PasswordHash == newPasswordHashed))
            {
                throw new ArgumentException("New password has been used before");
            }

            // Creating and saving new password
            Password newPassword = new Password(newPasswordHashed, user.Id);
            passwordRepository.Add(newPassword);
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

            // Check if username is in use
            if(userRepository.GetByUsername(username) != null)
            {
                throw new ArgumentException($"Username: {username} is already in use. Choose another.");
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

        public User LoginAsUser(string usernameInput, string passwordInput)
        {
            // Validate input
            if(string.IsNullOrEmpty(usernameInput))
            {
                throw new ArgumentNullException(nameof(usernameInput), "Username cannot be null or empty");
            }
            if (string.IsNullOrEmpty(passwordInput))
            {
                throw new ArgumentNullException(nameof(passwordInput), "Password cannot be null or empty");
            }

            // Get User if it exist
            User user = userRepository.GetByUsername(usernameInput);
            if(user == null)
            {
                throw new KeyNotFoundException("No user with username: " + usernameInput);
            }

            // Hash password input
            byte[] passwordHashedBytes = hashService.HashPassword(passwordInput, user.Salt);
            string passwordHashed = Convert.ToBase64String(passwordHashedBytes);

            // Validate Password hash
            Password activePassword = passwordRepository.GetUserActivePassword(user);
            if(activePassword.PasswordHash == passwordHashed)
            {
                return user;
            }

            throw new Exception("Password incorrect");
        }
    }
}
