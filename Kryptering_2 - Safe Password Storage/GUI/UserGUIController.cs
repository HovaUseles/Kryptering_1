using Kryptering_2___Safe_Password_Storage.GUI.Interfaces;
using Kryptering_2___Safe_Password_Storage.GUI.Views;
using Kryptering_2___Safe_Password_Storage.Managers;
using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.GUI
{
    /// <summary>
    /// Controller for user views
    /// </summary>
    internal static class UserGUIController
    {
        public static IUserManager userManager;

        /// <summary>
        /// Index view for User Controller
        /// </summary>
        /// <returns>The View</returns>
        public static IViewable Index(User activeUser = null)
        {
            if (activeUser == null)
            {
                return new LoginOrRegisterView();
            }
            else
            {
                return new UserMenuView(activeUser);
            }
        }

        /// <summary>
        /// Method for creating user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static IViewable CreateUser(string username, string password)
        {
            try
            {
                User createdUser = userManager.Create(username, password);
                return new UserMenuView(createdUser);
            }
            catch (Exception ex)
            {
                return new ErrorView(ex.Message, new RegisterUserView());
            }
        }

        /// <summary>
        /// For logging in as a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static IViewable Login(string username, string password)
        {
            try
            {
                User loginAs = userManager.LoginAsUser(username, password);
                return new UserMenuView(loginAs);
            }
            catch(KeyNotFoundException ex)
            {
                return new ErrorView(ex.Message, Index());
            }         
            catch (Exception ex) 
            { 
                return new ErrorView(ex.Message, new LoginView());
            }

        }

        /// <summary>
        /// For loggin out 
        /// </summary>
        /// <returns></returns>
        public static IViewable Logout()
        {
            return Index();
        }

        /// <summary>
        /// For changing password
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static IViewable ChangePassword(User activeUser, string oldPassword, string newPassword)
        {
            try
            {
                userManager.ChangePassword(activeUser, oldPassword, newPassword);
                return new UserMenuView(activeUser);
            }
            catch (ArgumentException ex)
            {
                return new ErrorView(ex.Message, new ChangePasswordView(activeUser));
            }
            catch (Exception ex)
            {
                return new ErrorView(ex.Message, new ChangePasswordView(activeUser));
            }
        }
    }
}
