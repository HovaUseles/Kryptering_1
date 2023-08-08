using Kryptering_2___Safe_Password_Storage.GUI.Interfaces;
using Kryptering_2___Safe_Password_Storage.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.GUI.Views
{
    internal class LoginView : IViewable
    {
        public IViewable Show()
        {
            Console.Clear();
            string userName = ViewComponents.GetUserInput("Write the new users name");
            string password = ViewComponents.GetUserInput("Write the users password");

            return UserGUIController.Login(userName, password);
        }
    }
}
