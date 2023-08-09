using Kryptering_2___Safe_Password_Storage.GUI.Controllers;
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
    internal class UserMenuView : IViewable
    {
        private readonly User loggedInUser;

        public UserMenuView(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
        }
        public IViewable Show()
        {
            Console.Clear();
            ViewComponents.DisplayViewHeader("User menu");
            ViewNavigationOption[] viewNavigationOptions = new ViewNavigationOption[]
            {
                new ViewNavigationOption("Change password", new ChangePasswordView(loggedInUser)),
                new ViewNavigationOption("Logout", UserGUIController.Logout()),
                new ViewNavigationOption("Quit", null)
            };
            ViewNavigationOption chosenOption = ViewComponents.GetNavigationChoice(viewNavigationOptions);
            if (chosenOption == null)
            {
                return this;
            }
            return chosenOption.GoToView;
        }
    }
}
