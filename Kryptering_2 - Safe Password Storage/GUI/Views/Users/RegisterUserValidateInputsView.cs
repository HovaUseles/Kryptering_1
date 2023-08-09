using Kryptering_2___Safe_Password_Storage.GUI.Controllers;
using Kryptering_2___Safe_Password_Storage.GUI.Interfaces;
using Kryptering_2___Safe_Password_Storage.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_2___Safe_Password_Storage.GUI.Views
{
    internal class RegisterUserValidateInputsView : IViewable
    {
        public string UsernameInput { get; set; }
        public string PasswordInput { get; set; }
        public RegisterUserValidateInputsView(string usernameInput, string passwordInput)
        {
            UsernameInput = usernameInput;
            PasswordInput = passwordInput;
        }
        public IViewable Show()
        {
            Console.Clear();
            ViewComponents.DisplayViewHeader("Validate your input");
            Console.WriteLine("Is this information correct?");
            Console.WriteLine($"Username: {UsernameInput}");
            Console.WriteLine($"Password: {PasswordInput}");
            Console.WriteLine();
            ViewNavigationOption[] viewNavigationOptions = new ViewNavigationOption[]
            {
                new ViewNavigationOption("OK", UserGUIController.CreateUser(UsernameInput, PasswordInput)),
                new ViewNavigationOption("No, i would like to change the information", new RegisterUserView())
            };
            ViewNavigationOption chosenOption = ViewComponents.GetNavigationChoice(viewNavigationOptions);
            return chosenOption.GoToView;
        }
    }
}
