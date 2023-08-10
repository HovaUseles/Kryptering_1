using Kryptering_4___Asymmetric_Encryption_Receiver.GUI.Utilities;
using Kryptering_4___Asymmetric_Encryption_Receiver.Managers;

namespace Kryptering_4___Asymmetric_Encryption_Receiver.GUI.Controllers
{
    internal class DecryptionViewController
    {
        public DecryptionManager DecryptionManager;

        public DecryptionViewController(DecryptionManager decryptionManager)
        {
            DecryptionManager = decryptionManager;
        }

        /// <summary>
        /// Display the start menu
        /// </summary>
        public void StartMenu()
        {
            Console.Clear();
            ViewComponents.DisplayViewHeader("Main menu");

            // Build navigation options
            ViewNavigationOption[] viewNavigationOptions = new ViewNavigationOption[]
            {
                new ViewNavigationOption("Generate key and decrypt message", GeneratePublicKey),
                new ViewNavigationOption("Decrypt message with existing keys", DecryptMessage),
                new ViewNavigationOption("Quit", null)
            };
            ViewNavigationOption chosenOption = ViewComponents.GetNavigationChoice(viewNavigationOptions);
            if (chosenOption.GoToView != null )
            {
                chosenOption.GoToView();
            }
            // Quit
        }

        /// <summary>
        /// Display view for generating encryption keys
        /// </summary>
        public void GeneratePublicKey()
        {
            Console.Clear();
            try
            {
                string publicKeyPath = DecryptionManager.GenKeys();
                ViewComponents.DisplayViewHeader("Keys generated");
                Console.WriteLine("Public key generated to: " + publicKeyPath);
                Console.ReadKey();
                DecryptMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                // Quit
            }

        }

        /// <summary>
        /// Displays View for decrypting message
        /// </summary>
        public void DecryptMessage()
        {
            string input = ViewComponents.GetUserInput("Write encrypted message");
            string decryptedMessage = DecryptionManager.DecryptMessage(input);
            Console.Clear();
            ViewComponents.DisplayViewHeader("Message decrypted");
            Console.WriteLine("Decrypted message: " + decryptedMessage);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            StartMenu(); // Return to main menu
        }
    }
}
