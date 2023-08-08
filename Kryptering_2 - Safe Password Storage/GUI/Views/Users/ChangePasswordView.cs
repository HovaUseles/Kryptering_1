using Kryptering_2___Safe_Password_Storage.GUI.Interfaces;
using Kryptering_2___Safe_Password_Storage.GUI.Utilities;
using Kryptering_2___Safe_Password_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.GUI.Views
{
    internal class ChangePasswordView : IViewable
    {
        // Parsing active user around the views to remember it
        private readonly User loggedInUser;
        public ChangePasswordView(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
        }

        public IViewable Show()
        {
            Console.Clear();
            string oldPassword = ViewComponents.GetUserInput("Write the old password");
            string newPassword = ViewComponents.GetUserInput("Write the new password");

            return UserGUIController.ChangePassword(loggedInUser, oldPassword, newPassword);
        }
    }
}
