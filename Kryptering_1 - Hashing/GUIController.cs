using Kryptering_1___Hashing.Managers.Interfaces;
using Kryptering_1___Hashing.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_1___Hashing
{
    /// <summary>
    /// Controller for the varies views, responsible for navigating to submenues.
    /// </summary>
    internal class GUIController
    {
        private readonly IHashManager hashManager;

        public GUIController(IHashManager hashManager)
        {
            this.hashManager = hashManager;
        }

        /// <summary>
        /// Show the Main menu of the application.
        /// </summary>
        public void ShowMainMenu() 
        {
            bool looper = true; // Looper variable to keep user in menu if they enters an unidentified menu input.
            do
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine();
                Console.WriteLine("1. Hash a value");
                Console.WriteLine("ESC. To quit");
                Console.WriteLine();
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        HashView hashView = new HashView(hashManager);
                        hashView.Show();
                        break;
                    case ConsoleKey.Escape:
                        looper = false;
                        break;
                    default:
                        Console.WriteLine("Input not recognised, please enter any key to try again");
                        Console.ReadKey();
                        break;
                }
            } while (looper);
        }

    }
}
