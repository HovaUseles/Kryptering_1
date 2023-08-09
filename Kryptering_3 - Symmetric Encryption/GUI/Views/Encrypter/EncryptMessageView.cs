using Kryptering_3___Symmetric_Encryption.Enums;
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
    internal class EncryptMessageView : IViewable
    {
        public IViewable Show()
        {
            string message = ViewComponents.GetUserInput("Write the message to encrypt (no spaces)");

            ViewComponents.DisplayViewHeader("Choose encrypter type");
            List<ViewNavigationOption> viewNavigationOptions = new List<ViewNavigationOption>();
            // Create navigation options from encryption type Enum
            foreach (EncryptionType encryptionType in Enum.GetValues(typeof(EncryptionType)))
            {
                viewNavigationOptions.Add(
                    new ViewNavigationOption(
                        encryptionType.ToString(), 
                        EncrypterController.EncryptMessage(message, encryptionType)
                        )
                    );
            }
            ViewNavigationOption chosenOption = ViewComponents.GetNavigationChoice(viewNavigationOptions.ToArray());
            return chosenOption.GoToView;
        }
    }
}
