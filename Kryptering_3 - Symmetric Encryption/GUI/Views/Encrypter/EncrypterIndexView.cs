using Kryptering_3___Symmetric_Encryption.GUI.Controllers;
using Kryptering_3___Symmetric_Encryption.GUI.Interfaces;
using Kryptering_3___Symmetric_Encryption.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Symmetric_Encryption.GUI.Views.Encrypter
{
    internal class EncrypterIndexView : IViewable
    {
        public IViewable Show()
        {
            ViewComponents.DisplayViewHeader("Encrypter");
            ViewNavigationOption[] viewNavigationOptions = new ViewNavigationOption[]
            {
                new ViewNavigationOption("Encrypt message", EncrypterController.EncryptMessage(string.Empty, null)),
                new ViewNavigationOption("Quit", null)
            };
            return ViewComponents.GetNavigationChoice(viewNavigationOptions).GoToView;
        }
    }
}
