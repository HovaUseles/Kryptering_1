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
    internal class ShowEncryptedMessageView : IViewable
    {
        private readonly string encryptedMessage;

        public ShowEncryptedMessageView(string encryptedMessage)
        {
            this.encryptedMessage = encryptedMessage;
        }
        public IViewable Show()
        {
            ViewComponents.DisplayViewHeader("Message Encrypted");
            Console.WriteLine("Encrypted message: " + encryptedMessage);
            Console.WriteLine();
            
            List<ViewNavigationOption> viewNavigationOptions = new List<ViewNavigationOption>();
            // Create navigation options from encryption type Enum
            foreach (EncryptionType encryptionType in Enum.GetValues(typeof(EncryptionType)))
            {
                viewNavigationOptions.Add(
                    new ViewNavigationOption(
                        "Decrypt with " + encryptionType.ToString(),
                        EncrypterController.DecryptMessage(encryptedMessage, encryptionType)
                        )
                    );
            }
            return ViewComponents.GetNavigationChoice(viewNavigationOptions.ToArray()).GoToView;
        }
    }
}
