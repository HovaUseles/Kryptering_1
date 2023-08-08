using Kryptering_2___Safe_Password_Storage.GUI.Interfaces;
using Kryptering_2___Safe_Password_Storage.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.GUI.Views
{
    internal class LoginOrRegisterView : IViewable
    {
        public IViewable Show()
        {
            Console.Clear();
            ViewComponents.DisplayViewHeader("Returning or new user?");
            ViewNavigationOption[] viewNavigationOptions = new ViewNavigationOption[]
            {
                new ViewNavigationOption("Register new user", new RegisterUserView()),
                new ViewNavigationOption("Login as existing user", new LoginView()),
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
